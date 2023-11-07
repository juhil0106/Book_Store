using Order.DataAccess.Models;

namespace Order.DataAccess.IRepository
{
    public interface IOrderRepository
    {
        Task<List<OrderDetails>> GetOrderDetails(int userId);
        Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails);
        Task<int> AddOrderItems(List<OrderItem> orderItem);
        Task<int> UpdateOrderDetails(OrderDetails orderDetails);
        Task<int> DeleteOrderDetails(int id);
    }
}
