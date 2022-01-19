using AutoMapper;
using ProjectStockDTOS;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.Map
{
    public class TdoMapper : AutoMapper.Profile 
                                                  
    {
        public TdoMapper()
        {
            
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<NotificationModel, NotificationDto>().ReverseMap();
            CreateMap<MarketModel, MarketDto>().ReverseMap();
            CreateMap<StockModel, StockDto>().ReverseMap();

            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<NotificationDto, NotificationModel>().ReverseMap();
            CreateMap<MarketDto, MarketModel>().ReverseMap();
            CreateMap<StockDto, StockModel>().ReverseMap();

        }

    }
}
