using AutoMapper;
using Shop.Application.Catalogs.CatalogTypes.CrudService;
using Shop_Admin_EndPoint.ViewModels.Catalogs;

namespace Shop_Admin_EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile : Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
        }
    }
}
