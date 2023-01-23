using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Advert.API.Entities.Concrete
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        public int BrandId { get; set; }
        public int ModelYear { get; set; }
        public string Descriptions { get; set; }
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
    }
}
