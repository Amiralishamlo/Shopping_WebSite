using MongoDB.Driver;

namespace Shop.Application.Interfaces.Contexts
{
    public interface IMongoDbContext<T>
    {
        public IMongoCollection<T> GetCollection(); 
    }
}
