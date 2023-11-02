using Book.API.Model;

namespace Book.API.Repositories.IRepositories
{
    public interface IBookImageRepository
    {
        Task<List<BookImage>> GetBookImagesByBook(string id);
        Task<bool> AddBookImage(BookImage bookImage);
        Task<bool> UpdateBookImage(BookImage bookImage);
        Task<bool> DeleteBookImage(string id);
    }
}
