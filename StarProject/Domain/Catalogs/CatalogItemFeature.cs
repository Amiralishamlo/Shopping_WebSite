using Domain.Attributes;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItemFeature
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
