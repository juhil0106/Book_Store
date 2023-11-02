using Book.API.Model;
using Book.API.ResponseModel;

namespace Book.API.Repositories.IRepositories
{
    public interface IBookRepository
    {
        Task<List<BookResponse>> GetBookDetails();
        Task<BookResponse> GetBookDetailById(string id);
        Task<List<BookResponse>> GetBookDetailsByGenreId(string id);
        Task<List<BookResponse>> GetBookDetailsByAuthor(string authorName);
        Task<List<string>> GetAuthorsName();
        Task<bool> AddBook(BookDetail book);
        Task<bool> UpdateBook(BookDetail book);
        Task<bool> DeleteBook(string id);
    }
}
