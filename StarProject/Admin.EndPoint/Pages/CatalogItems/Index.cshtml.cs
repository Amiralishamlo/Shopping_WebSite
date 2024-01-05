using Application.Catalogs.CatalohItems.CatalogItemServices;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemService _catalogItemService;

        public IndexModel(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }
        public PaginatedItemsDto<CatalogItemListItemDto> CatalogItems { get; set; }
        public void OnGet(int page=1,int pageSize=100)
        {
            CatalogItems = _catalogItemService.CatalogItemListItem(page,pageSize);
        }
    }
}
