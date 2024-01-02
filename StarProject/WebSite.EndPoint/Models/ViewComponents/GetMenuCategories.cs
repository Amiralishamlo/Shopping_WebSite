using Application.Catalogs.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class GetMenuCategories:ViewComponent
    {
        private readonly IGetMenuItemService getMenuItemService;

        public GetMenuCategories(IGetMenuItemService getMenuItemService)
        {
            this.getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var data = getMenuItemService.Execute();
            return View(viewName: "GetMenuCategories", model: data);
        }
    }
}
