using Discount.GRPC.Model;

namespace Discount.GRPC.Repository
{
    public interface IDiscountRepository
    {
        Task<BookDiscount> GetBookDiscount(string bookId);
    }
}
