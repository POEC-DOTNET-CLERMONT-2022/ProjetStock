using ApiApplication.Models;
using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,Client>().ReverseMap();
            CreateMap<Client, AuthenticateResponse>().ReverseMap();
        }

    }
}
