﻿namespace Shop.Application.Catalogs.CatalogTypes.CrudService
{
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? ParentCatalogTypeId { get; set; }
    }
}
