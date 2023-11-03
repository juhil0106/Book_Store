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
            CreateMap<AddOrderDetailsDto, OrderDetailsDto>().ReverseMap();
            CreateMap<AddOrderItemsDto, OrderItemsDto>().ReverseMap();
            CreateMap<UpdateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderDetailsDto, OrderDetails>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDto>().ReverseMap();
            CreateMap<BookQuantityDto, BookQuantityEvent>().ReverseMap();
        }
    }
}
