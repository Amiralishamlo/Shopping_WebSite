using Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService _PLPService;
        private readonly IGetCatalogItemPDPService _PDPService;
        public ProductController(IGetCatalogItemPLPService pLPService, IGetCatalogItemPDPService pDPService)
        {
            _PLPService = pLPService;
            _PDPService = pDPService;
        }

        public IActionResult Index(int page=1,int pageSize=20)
        {
            var data=_PLPService.Execute(page, pageSize);
            return View(data);
        }
        public IActionResult Details(int Id)
        {
            var data=_PDPService.Execute(Id);
            return View(data);
        }
    }
}
