using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalogs.CatalogTypes;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;

        public IndexModel(ICatalogTypeService catalogTypeService)
        {
            this.catalogTypeService = catalogTypeService;
        }

        public PaginatedItemsDto<CatalogTypeListDto> CataolType { get; set; }
        public void OnGet(int? parentId, int page = 1, int pageSize = 100)
        {
            CataolType = catalogTypeService.GetList(parentId, page, pageSize);
        }
    }
}
