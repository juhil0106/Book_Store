using AutoMapper;
using Basket.API.Model;
using EventBus.Messages.Event;

namespace Basket.API.MapperProfile
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CheckoutOrder, BasketCheckoutEvent>().ReverseMap();
            CreateMap<BasketItem, CheckoutOrderItem>().ReverseMap();
        }
    }
}
