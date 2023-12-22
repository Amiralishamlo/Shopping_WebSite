using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Catalogs.CatalogTypes.CrudService;
using Shop_Admin_EndPoint.ViewModels.Catalogs;

namespace Shop_Admin_EndPoint.Pages.CatalogType
{
    public class EditModel : PageModel
    {
        private readonly ICatalogService _CatalogService;
        private readonly IMapper _mapper;
        public EditModel(ICatalogService catalogService, IMapper mapper)
        {
            _CatalogService = catalogService;
            _mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel catalogTypeView { get; set; } = new CatalogTypeViewModel();
        public List<string>? Message { get; set; }
        public void OnGet(int Id)
        {
            var model=_CatalogService.FindById(Id);
            if(model.IsSuccess)
                catalogTypeView=_mapper.Map<CatalogTypeViewModel>(model.Data);
            Message = model.Message;
        }
        public IActionResult OnPost() 
        {
            var model = _mapper.Map<CatalogTypeDto>(catalogTypeView);
            var result=_CatalogService.Edit(model);
            Message=result.Message;
            catalogTypeView = _mapper.Map<CatalogTypeViewModel>(result.Data);
            return Page();
        }
    }
}
