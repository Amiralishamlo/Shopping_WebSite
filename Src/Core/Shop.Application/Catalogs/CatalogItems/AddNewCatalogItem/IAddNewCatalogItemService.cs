using Shop.Application.Dtos;

namespace Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
	public interface IAddNewCatalogItemService
	{
		BaseDto<int> Execute(AddNewCaatalogItemDto addNewCatalog);
	}
} 
 