using Microsoft.EntityFrameworkCore;
using Shop.Domain.Catalogs;

namespace Shop.Application.Interfaces.Contexts
{
	public interface IDataBaseContext
    {
		DbSet<CatalogItemImage> CatalogItemImages { get; set; }
		DbSet<CatalogItemFeature> CatalogItemFeatures { get; set; }
		DbSet<CatalogItem> CatalogItems { get; set; }
		DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
