using Dapper;
using Discount.GRPC.Model;
using Npgsql;

namespace Discount.GRPC.Repository
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
    }
}
