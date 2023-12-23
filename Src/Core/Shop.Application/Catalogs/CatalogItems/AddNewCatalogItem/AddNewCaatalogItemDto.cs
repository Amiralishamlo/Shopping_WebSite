namespace Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public class AddNewCaatalogItemDto
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; } 
        public int CatalogBranId { get; set; }
		public int AvailableStock { get; set; }
		public int RestockThreshold { get; set; }
		public int MaxStockThreshold { get; set; }
		public List<AddNewCatalogItemFeature_Dto> Features { get; set; }
		public List<AddNewCatalogItemImage_Dto> Images { get; set; }
	}
} 
 