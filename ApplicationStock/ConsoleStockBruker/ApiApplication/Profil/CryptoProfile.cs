using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    public class CryptoProfile :AutoMapper.Profile
    {
        public CryptoProfile()
        {
            CreateMap<CryptoDto, Crypto>().ReverseMap();
        }
    }
}