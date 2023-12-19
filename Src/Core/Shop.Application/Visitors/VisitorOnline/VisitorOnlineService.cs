using MongoDB.Driver;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Visitors;

namespace Shop.Application.Visitors.VisitorOnline
{
	public class VisitorOnlineService : IVisitorOnlineService
	{
		private readonly IMongoDbContext<OnlineVisitor> _mongoDbContext;
		private readonly IMongoCollection<OnlineVisitor> _OnlineVisitorMongoCollection;

		public VisitorOnlineService(IMongoDbContext<OnlineVisitor> mongoDbContext)
		{
			_mongoDbContext = mongoDbContext;
			_OnlineVisitorMongoCollection = _mongoDbContext.GetCollection();
		}
        
        public void ConnectUser(string ClinetId)
		{
			var exit = _OnlineVisitorMongoCollection.AsQueryable().FirstOrDefault(x => x.ClientId == ClinetId);
			if (exit == null) 
			{
				_OnlineVisitorMongoCollection.InsertOne(new OnlineVisitor
				{
					ClientId = ClinetId,
					Time = DateTime.Now,
				});
			}
		}

		public void DisconnectUser(string ClinetId)
		{
			_OnlineVisitorMongoCollection.FindOneAndDelete(x => x.ClientId == ClinetId);
		}

		public int GetCount()
		{
			int online=_OnlineVisitorMongoCollection.AsQueryable().Count();
			return online;
		}
	}
}
