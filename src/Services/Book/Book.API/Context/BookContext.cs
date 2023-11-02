using Book.API.Model;
using MongoDB.Driver;

namespace Book.API.Context
{
    public class BookContext : IBookContext
    {
        public BookContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Books = database.GetCollection<BookDetail>(configuration["DatabaseSettings:BookCollection"]);
            BookImages = database.GetCollection<BookImage>(configuration["DatabaseSettings:BookImagesCollection"]);
            Genres = database.GetCollection<Genre>(configuration["DatabaseSettings:GenreCollection"]);
        }

        public IMongoCollection<BookDetail> Books { get; set; }
        public IMongoCollection<BookImage> BookImages { get; set; }
        public IMongoCollection<Genre> Genres { get; set; }
    }
}
 