using MongoDB.Bson.Serialization.Attributes;

namespace Book.API.Model
{
    public class BookDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string GenreId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; } = null!;
        public int PublishYear { get; set; }
        public string Language { get; set; } = null!;
    }
}
