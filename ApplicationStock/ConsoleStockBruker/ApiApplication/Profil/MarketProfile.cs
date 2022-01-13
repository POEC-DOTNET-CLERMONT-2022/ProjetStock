using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            CreateMap<MarketDto, Market>().ReverseMap();
        }
    }
}
