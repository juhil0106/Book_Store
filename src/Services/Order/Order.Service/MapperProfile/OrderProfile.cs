using AutoMapper;
using EventBus.Messages.Event;
using Order.DataAccess.Models;
using Order.Service.Dtos;

namespace Order.Service.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddOrderDetailsDto, OrderDetails>().ReverseMap();
            CreateMap<AddOrderItemsDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderDetailsDto, OrderDetails>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDto>().ReverseMap();
            CreateMap<BasketCheckoutEvent, AddOrderDetailsDto>().ReverseMap();
            CreateMap<CheckoutOrderItem, AddOrderItemsDto>().ReverseMap();
            CreateMap<BookQuantityDto, BookQuantityEvent>().ReverseMap();
            CreateMap<BookDto, BookEvent>().ReverseMap();
        }
    }
}
