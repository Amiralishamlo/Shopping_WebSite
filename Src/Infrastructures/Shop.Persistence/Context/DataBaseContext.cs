using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Attributes;
using Shop.Domain.Users;

namespace Shop.Persistence.Context
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved");
                }
            }
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
                }
            }
            return base.SaveChanges();
        }
    }
}
