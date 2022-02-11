using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace ApiApplication.Profil
{
    public class StocksProfile : Profile
    {
        public StocksProfile()
        {
            CreateMap<StockDto, Stock>().ReverseMap();
        }
    }
}
