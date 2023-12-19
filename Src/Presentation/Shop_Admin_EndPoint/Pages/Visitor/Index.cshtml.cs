using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Visitors.GetTodayReport;
using Shop.Application.Visitors.VisitorOnline;

namespace Shop_Admin_EndPoint.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReportService _getTodayReportService;
        public ResultTodayReportDto ResultTodayReport;
        private readonly IVisitorOnlineService _visitorOnline;
        public int OnlineUserCount;

		public IndexModel(IGetTodayReportService getTodayReportService, IVisitorOnlineService visitorOnline)
		{
			_getTodayReportService = getTodayReportService;
			_visitorOnline = visitorOnline;
		}
		public void OnGet()
        {
			OnlineUserCount=_visitorOnline.GetCount();
			ResultTodayReport = _getTodayReportService.Execute();
        }
    }
}
