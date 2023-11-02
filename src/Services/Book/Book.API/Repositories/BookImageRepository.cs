using Book.API.Context;
using Book.API.Model;
using Book.API.Repositories.IRepositories;
using MongoDB.Driver;

namespace Book.API.Repositories
{
    public class BookImageRepository : IBookImageRepository
    {
        private readonly IBookContext _context;

        public BookImageRepository(IBookContext context)
        {
            _context = context;
        }

        public async Task<List<BookImage>> GetBookImagesByBook(string id)
        {
            var bookImages = await _context.BookImages.Find(x => x.BookId == id).ToListAsync();
            return bookImages;
        }

        public async Task<bool> AddBookImage(BookImage bookImage)
        {
            try
            {
                await _context.BookImages.InsertOneAsync(bookImage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBookImage(BookImage bookImage)
        {
            var updatedBookImage = await _context.BookImages.FindOneAndReplaceAsync(x => x.Id == bookImage.Id, replacement: bookImage);
            if (updatedBookImage == null) return false;
            return true;
        }

        public async Task<bool> DeleteBookImage(string id)
        {
            var deletedBookImages = await _context.BookImages.FindOneAndDeleteAsync(x => x.Id == id);
            if (deletedBookImages == null) return false;
            return true;
        }
    }
}
