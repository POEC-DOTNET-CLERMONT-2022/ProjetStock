using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    //TODO : //Uniquement entit�s vers DTO 
    public class CryptoProfile :AutoMapper.Profile
    {
        public CryptoProfile()
        {
            CreateMap<CryptoDto, Crypto>().ReverseMap();
        }
    }
}