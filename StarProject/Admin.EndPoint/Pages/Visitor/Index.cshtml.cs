using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Visitors.GetTodayReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Visitor
{

    public class IndexModel : PageModel
    {
        private readonly IGetTodayReportService _getTodayReportService;
        public ResultTodayReportDto ResultTodayReport;

        public IndexModel(  IGetTodayReportService getTodayReportService)
        {
            _getTodayReportService = getTodayReportService;

        }
        public void OnGet()
        {
            ResultTodayReport= _getTodayReportService.Execute();
        }
    }
}
