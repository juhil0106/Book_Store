using Dapper;
using Discount.API.Model;
using Npgsql;

namespace Discount.API.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private NpgsqlConnection _connection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
        }

        public async Task<BookDiscount> GetBookDiscount(string bookId)
        {
            var bookDiscount = await _connection.QueryFirstOrDefaultAsync<BookDiscount>("select * from BookDiscount where BookId = @BookId", new { BookId = bookId });

            if (bookDiscount == null)
            {
                return new BookDiscount { BookId = bookId, Discount = 0 };
            }

            return bookDiscount;
        }

        public async Task<bool> AddBookDiscount(BookDiscount bookDiscount)
        {
            var affected = await _connection.ExecuteAsync("INSERT INTO BookDiscount (BookId, Discount) VALUES (@BookId, @Discount)", new { BookId = bookDiscount.BookId, Discount = bookDiscount.Discount });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateBookDiscount(BookDiscount bookDiscount)
        {
            var affected = await _connection.ExecuteAsync("UPDATE BookDiscount SET BookId = @BookId, Discount = @Discount WHERE Id = @Id", new { Id = bookDiscount.Id, BookId = bookDiscount.BookId, Discount = bookDiscount.Discount });

            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> DeleteBookDiscount(string bookId)
        {
            var affected = await _connection.ExecuteAsync("DELETE FROM BookDiscount Where BookId = @BookId", new { BookId = bookId });

            if (affected == 0) return false;

            return true;
        }
    }
}
