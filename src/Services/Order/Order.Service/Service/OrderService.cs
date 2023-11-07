using AutoMapper;
using EventBus.Messages.Event;
using MassTransit;
using Order.DataAccess.IRepository;
using Order.DataAccess.Models;
using Order.Service.Dtos;
using Order.Service.IService;

namespace Order.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<List<OrderDetailsDto>> GetOrderDetailsAsync(int userId)
        {
            var order = await _orderRepository.GetOrderDetails(userId);
            return _mapper.Map<List<OrderDetailsDto>>(order);
        }

        public async Task<int> AddOrderDetailsAsync(AddOrderDetailsDto addOrder)
        {
            var mapOrderDetails = _mapper.Map<OrderDetails>(addOrder);
            var order = await _orderRepository.AddOrderDetails(mapOrderDetails);

            if (order is not null)
            {
                List<BookQuantityDto> bookQuantities = new List<BookQuantityDto>();
                foreach(var item in order.Items)
                {
                    BookQuantityDto bookQuantity = new BookQuantityDto();
                    bookQuantity.Quantity = item.Quantity;
                    bookQuantity.BookId = item.BookId;
                    bookQuantities.Add(bookQuantity);
                }
                var bookDto = new BookDto() { BookQuantities = bookQuantities};

                var eventMessage = _mapper.Map<BookEvent>(bookDto);
                await _publishEndpoint.Publish(eventMessage);
                return order.Id;
            }

            return 0;
        }

        public async Task<int> UpdateOrderDetailsAsync(UpdateOrderDetailsDto updateOrder)
        {
            var mapOrderDetails = _mapper.Map<OrderDetails>(updateOrder);
            return await _orderRepository.UpdateOrderDetails(mapOrderDetails);
        }

        public async Task<int> DeleteOrderDetailsAsync(int id)
        {
            return await _orderRepository.DeleteOrderDetails(id);
        }
    }
}
