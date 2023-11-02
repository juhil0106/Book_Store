using Book.API.Context;
using Book.API.Model;
using Book.API.Repositories.IRepositories;
using Book.API.ResponseModel;
using MongoDB.Driver;

namespace Book.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _context;
        private readonly IBookImageRepository _bookImageRepository;

        public BookRepository(IBookContext context, IBookImageRepository bookImageRepository)
        {
            _context = context;
            _bookImageRepository = bookImageRepository;
        }

        public async Task<List<BookResponse>> GetBookDetails()
        {
            var books = await _context.Books.Aggregate().ToListAsync();
            var bookResponseList = new List<BookResponse>();
            foreach (var book in books)
            {
                var bookImages = await _bookImageRepository.GetBookImagesByBook(book.Id);
                var bookResponse = new BookResponse
                {
                    BookDetail = book,
                    BookImages = bookImages
                };
                bookResponseList.Add(bookResponse);
            }
            return bookResponseList;
        }

        public async Task<BookResponse> GetBookDetailById(string id)
        {
            var book = await _context.Books.Find(x => x.Id == id).FirstOrDefaultAsync();
            var bookImages = await _bookImageRepository.GetBookImagesByBook(book.Id);
            var bookResponse = new BookResponse
            {
                BookDetail = book,
                BookImages = bookImages
            };
            return bookResponse;
        }

        public async Task<List<BookResponse>> GetBookDetailsByGenreId(string id)
        {
            var books = await _context.Books.Find(x => x.GenreId == id).ToListAsync();
            var bookResponseList = new List<BookResponse>();
            foreach (var book in books)
            {
                var bookImages = await _bookImageRepository.GetBookImagesByBook(book.Id);
                var bookResponse = new BookResponse
                {
                    BookDetail = book,
                    BookImages = bookImages
                };
                bookResponseList.Add(bookResponse);
            }
            return bookResponseList;
        }

        public async Task<List<BookResponse>> GetBookDetailsByAuthor(string authorName)
        {
            var books = await _context.Books.Find(x => x.AuthorName == authorName).ToListAsync();
            var bookResponseList = new List<BookResponse>();
            foreach (var book in books)
            {
                var bookImages = await _bookImageRepository.GetBookImagesByBook(book.Id);
                var bookResponse = new BookResponse
                {
                    BookDetail = book,
                    BookImages = bookImages
                };
                bookResponseList.Add(bookResponse);
            }
            return bookResponseList;
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
