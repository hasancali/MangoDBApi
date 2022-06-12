using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoDBApi.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }
    }
}
