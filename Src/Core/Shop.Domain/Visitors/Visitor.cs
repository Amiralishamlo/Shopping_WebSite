using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Domain.Visitors
{
    public class Visitor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string RefeeereLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersion Browser { get; set; }
        public VisitorVersion OperationSystem { get; set; }
        public Device Device { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
