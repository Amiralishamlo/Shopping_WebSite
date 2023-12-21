using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Attributes;
using Shop.Domain.Catalogs;
using Shop.Domain.Users;
using Shop.Persistence.EntityConfigurations;
using Shop.Persistence.Seeds;

namespace Shop.Persistence.Context
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            var assembly=typeof(CatalogBrandEntityTypeConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            DataBaseContextSeed.CatalogSeed(modelBuilder);
            modelBuilder.Entity<CatalogType>().HasQueryFilter(x => EF.Property<bool>(x, "IsRemoved") == false);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified ||
                x.State == EntityState.Added ||
                x.State == EntityState.Deleted
                );
            foreach( var entry in modifiedEntries )
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inster = entityType?.FindProperty("InsertTime");
                var update = entityType?.FindProperty("UpdateTime");
                var RomoveTime = entityType?.FindProperty("RemoveTime");
                var Romove = entityType?.FindProperty("IsRemoved");
                if (entry.State == EntityState.Added && inster!=null)
                {
                    entry.Property("InsertTime").CurrentValue=DateTime.Now;
                }
                if (entry.State == EntityState.Modified && update != null)
                {
                    entry.Property("UpdateTime").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Deleted && RomoveTime != null && Romove!=null)
                {
                    entry.Property("RemoveTime").CurrentValue = DateTime.Now;
                    entry.Property("IsRemoved").CurrentValue = true;
                    entry.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
    }
}
