﻿using Order.Service.Dtos;

namespace Order.Service.IService
{
    public interface IOrderService
    {
        Task<List<OrderDetailsDto>> GetOrderDetailsAsync(int userId);
        Task<int> AddOrderDetailsAsync(AddOrderDetailsDto addOrder);
        Task<int> UpdateOrderDetailsAsync(UpdateOrderDetailsDto updateOrder);
        Task<int> DeleteOrderDetailsAsync(int id);
    }
}
