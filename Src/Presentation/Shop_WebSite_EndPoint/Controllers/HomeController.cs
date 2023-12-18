using Microsoft.AspNetCore.Mvc;
using Shop.Application.Visitors.SaveVisitorInfo;
using Shop_WebSite_EndPoint.Utilities.Filters;

namespace Shop_WebSite_EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
