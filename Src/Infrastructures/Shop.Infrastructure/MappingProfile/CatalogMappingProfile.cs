using AutoMapper;
using Shop.Application.Catalogs.CatalogTypes;
using Shop.Domain.Catalogs;

namespace Shop.Infrastructure.MappingProfile
{
    public class CatalogMappingProfile:Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>().ForMember(dest=>dest.SubTypeCount,options=>options.MapFrom(src=>src.SubType.Count));
        }
    }
}
