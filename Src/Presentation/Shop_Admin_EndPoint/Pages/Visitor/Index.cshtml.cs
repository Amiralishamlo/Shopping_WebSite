using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Visitors.GetTodayReport;

namespace Shop_Admin_EndPoint.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReportService _getTodayReportService;
        public ResultTodayRepotDto ResultTodayReport;

        public IndexModel(IGetTodayReportService getTodayReportService)
        {
            _getTodayReportService = getTodayReportService;
        }
        public void OnGet()
        {
            ResultTodayReport = _getTodayReportService.Execute();
        }
    }
}
