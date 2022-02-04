using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStockEntity;
using ProjectStockModels.Model;
using ProjectStockDTOS;

namespace ProjectStockModels.Mapper
{
   public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<UserModel,Client>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<NotificationModel, NotificationDto>().ReverseMap();
            CreateMap<MarketModel, MarketDto>().ReverseMap();
            CreateMap<StockModel, StockDto>().ReverseMap();

            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<OrderModel,OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<Order,OrderModel>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<NotificationDto, NotificationModel>().ReverseMap();
            CreateMap<MarketDto, MarketModel>().ReverseMap();
            CreateMap<StockDto, StockModel>().ReverseMap();

        }

    }
}
