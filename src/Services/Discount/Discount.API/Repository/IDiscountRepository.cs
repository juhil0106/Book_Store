using Discount.API.Model;

namespace Discount.API.Repository
{
    public interface IDiscountRepository
    {
        Task<BookDiscount> GetBookDiscount(string bookId);
        Task<bool> AddBookDiscount(BookDiscount bookDiscount);
        Task<bool> UpdateBookDiscount(BookDiscount bookDiscount);
        Task<bool> DeleteBookDiscount(string bookId);
    }
}
