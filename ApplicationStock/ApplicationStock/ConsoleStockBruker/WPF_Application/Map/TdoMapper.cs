using ApiApplication.Models;
using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
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
            CreateMap<Client, UserModel>().ReverseMap();

            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<NotificationDto, NotificationModel>().ReverseMap();
            CreateMap<MarketDto, MarketModel>().ReverseMap();
            CreateMap<StockDto, StockModel>().ReverseMap();

            CreateMap<UserModel, DeleteClass>().ReverseMap();
 
            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            

        }   

    }
}
