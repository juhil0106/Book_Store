using AutoMapper;
using Discount.GRPC.Model;
using Discount.GRPC.Protos;

namespace Discount.GRPC.MapperProfile
{
    public class BookDiscountProfile : Profile
    {
        public BookDiscountProfile()
        {
            CreateMap<BookDiscount, DiscountModel>().ReverseMap();
        }
    }
}
