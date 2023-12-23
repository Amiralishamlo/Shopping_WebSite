using AutoMapper;
using Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Shop.Application.Catalogs.CatalogItems.CatalogItemServices;
using Shop.Application.Catalogs.CatalogTypes.CrudService;
using Shop.Application.Catalogs.GetMenuItem;
using Shop.Domain.Catalogs;

namespace Shop.Infrastructure.MappingProfile
{
    public class CatalogMappingProfile:Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>().ForMember(dest=>dest.SubTypeCount,options=>options.MapFrom(src=>src.SubType.Count));
			CreateMap<CatalogType, MenuItemDto>()
				.ForMember(dest => dest.Name, opt =>
				opt.MapFrom(src => src.Type))
				.ForMember(dest => dest.ParentId, opt =>
				opt.MapFrom(src => src.ParentCatalogTypeId))
				.ForMember(dest => dest.SubMenu, opt =>
				opt.MapFrom(src => src.SubType));

			CreateMap<CatalogItemFeature, AddNewCatalogItemFeature_Dto>().ReverseMap();
			CreateMap<CatalogItemImage,AddNewCatalogItemImage_Dto>().ReverseMap();
			CreateMap<CatalogItem, AddNewCaatalogItemDto>()
				.ForMember(dest => dest.Features, opt =>
				opt.MapFrom(src => src.CatalogItemFeatures))
				.ForMember(dest => dest.Images, opt =>
				opt.MapFrom(src => src.CatalogItemImages)).ReverseMap();

			CreateMap<CatalogBrand, CatalogBrandDto>().ReverseMap();
			CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();
		}
    }
}
