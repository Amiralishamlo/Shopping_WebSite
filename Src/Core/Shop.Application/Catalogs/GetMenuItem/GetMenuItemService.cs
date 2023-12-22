using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Contexts;

namespace Shop.Application.Catalogs.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _Context;
        private readonly IMapper _Mapper;
        public GetMenuItemService(IDataBaseContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public List<MenuItemDto> Execute()
        {
            var catalogType=_Context.CatalogTypes.Include(x=>x.ParentCatalogType).ToList();
            var data=_Mapper.Map<List<MenuItemDto>>(catalogType);
            return data;
        }
    }
}
