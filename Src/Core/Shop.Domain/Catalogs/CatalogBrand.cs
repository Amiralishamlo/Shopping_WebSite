using Shop.Domain.Attributes;

namespace Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }
}
