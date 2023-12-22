using Microsoft.AspNetCore.Mvc;
using Shop.Application.Catalogs.GetMenuItem;

namespace Shop_WebSite_EndPoint.Models.ViewComponents
{
    public class GetMenuCategories:ViewComponent
    {
        private readonly IGetMenuItemService _menuItemService;
        public GetMenuCategories(IGetMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _menuItemService.Execute();
            return View(viewName:"GetMenuCategories",model:data);
        }
    }
}
