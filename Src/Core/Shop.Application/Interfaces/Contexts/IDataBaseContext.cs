using Microsoft.EntityFrameworkCore;
using Shop.Domain.Users;

namespace Shop.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
