using AutoMapper;
using Shop.Application.Dtos;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Catalogs;

namespace Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
	public class AddNewCatalogItemService : IAddNewCatalogItemService
	{
		private readonly IDataBaseContext _context;
		private readonly IMapper _mapper;

		public AddNewCatalogItemService(IMapper mapper, IDataBaseContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public BaseDto<int> Execute(AddNewCaatalogItemDto addNewCatalog)
		{
			var catalogItem = _mapper.Map<CatalogItem>(addNewCatalog);
			_context.CatalogItems.Add(catalogItem);
			_context.SaveChanges();
			return new BaseDto<int>(catalogItem.Id, new List<string> {"با موفقیت ثبت شد" },true);
		}
	}
} 
 