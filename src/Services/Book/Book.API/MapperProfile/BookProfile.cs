using AutoMapper;
using Book.API.ResponseModel;
using EventBus.Messages.Event;

namespace Book.API.MapperProfile
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookQuantityEvent, BookQuantity>().ReverseMap();
            CreateMap<BookMessage, BookEvent>().ReverseMap();
        }
    }
}
