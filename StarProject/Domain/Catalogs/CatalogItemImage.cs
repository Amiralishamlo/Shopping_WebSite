using Domain.Attributes;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItemImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }

    }
}
