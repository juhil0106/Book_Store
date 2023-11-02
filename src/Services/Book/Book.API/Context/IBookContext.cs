using MongoDB.Driver;
using Book.API.Model;

namespace Book.API.Context
{
    public interface IBookContext
    {
        IMongoCollection<BookDetail> Books { get; set; }
        IMongoCollection<BookImage> BookImages { get; set; }
        IMongoCollection<Genre> Genres { get; set; }
    }
}
