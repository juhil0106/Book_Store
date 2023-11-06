using Book.API.Model;
using Book.API.ResponseModel;

namespace Book.API.Repositories.IRepositories
{
    public interface IBookRepository
    {
        Task<List<BookDetail>> GetBookDetails();
        Task<BookDetail> GetBookDetailById(string id);
        Task<List<BookDetail>> GetBookDetailsByGenreId(string id);
        Task<List<BookDetail>> GetBookDetailsByAuthor(string authorName);
        Task<List<string>> GetAuthorsName();
        Task<bool> AddBook(BookDetail book);
        Task<bool> UpdateBook(BookDetail book);
        Task<bool> DeleteBook(string id);
    }
}
