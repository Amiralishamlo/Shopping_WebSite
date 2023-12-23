using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Shop.Application.Catalogs.CatalogItems.CatalogItemServices;
using Shop.Application.Dtos;

namespace Shop_Admin_EndPoint.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
		private readonly IAddNewCatalogItemService addNewCatalogItemService;
		private readonly ICatalogItemService catalogItemService;
		//private readonly IImageUploadService imageUploadService;
		public CreateModel(ICatalogItemService catalogItemService, IAddNewCatalogItemService addNewCatalogItemService)
		{
			this.catalogItemService = catalogItemService;
			this.addNewCatalogItemService = addNewCatalogItemService;
		}
		public SelectList Categories { get; set; }
		public SelectList Brands { get; set; }

		[BindProperty]
		public AddNewCaatalogItemDto Data { get; set; }
		[BindProperty]
		public List<IFormFile> Files { get; set; }

		public void OnGet()
        {
			Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
			Brands = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");
		}
		public JsonResult OnPost()
		{
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(0, allErrors.Select(p => p.ErrorMessage).ToList(), false));
            }
			// ToDo
			return new JsonResult("");
        }
    }
}
