using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Catalogs.CatalogTypes.CrudService;
using Shop_Admin_EndPoint.ViewModels.Catalogs;

namespace Shop_Admin_EndPoint.Pages.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogService _CatalogService;
        private readonly IMapper _mapper;
        public CreateModel(ICatalogService catalogService, IMapper mapper)
        {
            _CatalogService = catalogService;
            _mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel catalogTypeView { get; set; }=new CatalogTypeViewModel();
        public List<string>? Message { get; set; }
        public void OnGet(int? parentId)
        {
            catalogTypeView.ParentCatalogTypeId = parentId;
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var model = _mapper.Map<CatalogTypeDto>(catalogTypeView);
            var result=_CatalogService.Add(model);
            if(result.IsSuccess)
            {
                return RedirectToPage("index", new { parentid = catalogTypeView.ParentCatalogTypeId });
            }
            Message=result.Message;
            return Page();
        }
    }
}
