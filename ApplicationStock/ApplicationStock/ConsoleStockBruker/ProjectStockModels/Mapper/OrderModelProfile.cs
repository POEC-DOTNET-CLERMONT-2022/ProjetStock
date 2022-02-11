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
   public class OrderModelProfile : Profile
    {
        public OrderModelProfile()
        {
            CreateMap<OrderModel,Order>().ReverseMap();
            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();

        }
    }
}
