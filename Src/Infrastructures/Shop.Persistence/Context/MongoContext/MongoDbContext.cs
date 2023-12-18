using MongoDB.Driver;
using Shop.Application.Interfaces.Contexts;

namespace Shop.Persistence.Context.MongoContext
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> mongoCollection;

        public MongoDbContext()
        {
            var client=new MongoClient();
            db = client.GetDatabase("VisitorDb");
            mongoCollection = db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> GetCollection()
        {
            return mongoCollection;
        }
    }
}
