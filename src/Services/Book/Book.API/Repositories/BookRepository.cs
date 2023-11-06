using Book.API.Context;
using Book.API.Model;
using Book.API.Repositories.IRepositories;
using MongoDB.Driver;

namespace Book.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _context;

        public BookRepository(IBookContext context)
        {
            _context = context;
        }

        public async Task<List<BookDetail>> GetBookDetails()
        {
            var books = await _context.Books.Aggregate().ToListAsync();

            return books;
        }

        public async Task<BookDetail> GetBookDetailById(string id)
        {
            var book = await _context.Books.Find(x => x.Id == id).FirstOrDefaultAsync();

            return book;
        }

        public async Task<List<BookDetail>> GetBookDetailsByGenreId(string id)
        {
            var books = await _context.Books.Find(x => x.GenreId == id).ToListAsync();
            return books;
        }

        public async Task<List<BookDetail>> GetBookDetailsByAuthor(string authorName)
        {
            var books = await _context.Books.Find(x => x.AuthorName == authorName).ToListAsync();
            return books;
        }

        public async Task<List<string>> GetAuthorsName()
        {
            var authorsName = await _context.Books.Aggregate().ToListAsync();
            return authorsName.Select(x => x.AuthorName).Distinct().ToList();
        }

        public async Task<bool> AddBook(BookDetail book)
        {
            try
            {
                await _context.Books.InsertOneAsync(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBook(BookDetail book)
        {
            var updatedBook = await _context.Books.FindOneAndReplaceAsync(x => x.Id == book.Id, replacement: book);
            if (updatedBook == null) return false;
            return true;
        }

        public async Task<bool> DeleteBook(string id)
        {
            var deletedBook = await _context.Books.FindOneAndDeleteAsync(x => x.Id == id);
            if (deletedBook == null) return false;
            return true;
        }
    }
}
