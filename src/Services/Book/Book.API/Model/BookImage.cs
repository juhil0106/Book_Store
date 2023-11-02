using MongoDB.Bson.Serialization.Attributes;

namespace Book.API.Model
{
    public class BookImage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string BookId { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
