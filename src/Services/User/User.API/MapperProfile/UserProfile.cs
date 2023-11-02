using AutoMapper;
using User.API.Dtos;
using User.API.Models;

namespace User.API.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDto, UserDetails>().ReverseMap();
            CreateMap<UserDetails, UserDetailsDto>().ReverseMap();
            CreateMap<AddUserChoiceDto, UserChoice>().ReverseMap();
            CreateMap<UserChoice, UserChoiceDto>().ReverseMap();
            CreateMap<UpdateUserChoicesDto, UserChoice>().ReverseMap();
        }
    }
}
