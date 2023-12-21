using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Catalogs.CatalogTypes;
using Shop.Application.Dtos;

namespace Shop_Admin_EndPoint.Pages.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogService _CatalogService;

        public IndexModel(ICatalogService catalogService)
        {
            _CatalogService = catalogService;
        }
        public PaginatedItemsDto<CatalogTypeListDto> catalogType { get; set; }

        public void OnGet(int? parentId,int Page,int PageSize=100)
        {
            catalogType = _CatalogService.GetList(parentId,Page,PageSize);
        }
    }
}
