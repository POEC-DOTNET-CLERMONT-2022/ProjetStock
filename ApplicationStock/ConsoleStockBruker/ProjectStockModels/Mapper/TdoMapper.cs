using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Mapper
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

            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }

    }
}
