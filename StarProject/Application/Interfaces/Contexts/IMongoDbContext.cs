using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Contexts
{
    public interface IMongoDbContext<T>
    {
        public IMongoCollection<T> GetCollection();
    }
}
