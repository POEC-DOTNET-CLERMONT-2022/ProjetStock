using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
