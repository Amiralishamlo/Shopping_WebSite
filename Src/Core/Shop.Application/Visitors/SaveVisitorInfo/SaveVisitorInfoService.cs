using MongoDB.Driver;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Visitors;
namespace Shop.Application.Visitors.SaveVisitorInfo
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _visitorMongoCollection;
        public SaveVisitorInfoService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _visitorMongoCollection = _mongoDbContext.GetCollection();
        }

        public void Execute(RequestSaveVisitorDto request)
        {
            _visitorMongoCollection.InsertOne(new Visitor
            {
                Browser=new VisitorVersion { Family=request.Browser.Family, Version=request.Browser.Version},
                OperationSystem = new VisitorVersion { Family = request.Browser.Family, Version = request.Browser.Version },
                Device=new Device { Brand=request.Device.Brand,IsSpider=request.Device.IsSpider,Model=request.Device.Model, Family = request.Device.Family },
                CurrentLink=request.CurrentLink,
                Ip=request.Ip,
                Method=request.Method,
                PhysicalPath=request.PhysicalPath,
                Protocol=request.Protocol,
                RefeeereLink = request.RefeeereLink
            });
        }
    }
}
