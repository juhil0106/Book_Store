using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Context;
using Order.DataAccess.IRepository;
using Order.DataAccess.Models;

namespace Order.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails)
        {
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<int> AddOrderItems(List<OrderItem> orderItem)
        {
            await _context.OrderItems.AddRangeAsync(orderItem);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Update(orderDetails);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrderDetails(int id)
        {
            var order = await _context.OrderDetails.FindAsync(id);

            if (order is null)
                return 0;

            _context.OrderDetails.Remove(order);
            return await _context.SaveChangesAsync();
        }
    }
}
