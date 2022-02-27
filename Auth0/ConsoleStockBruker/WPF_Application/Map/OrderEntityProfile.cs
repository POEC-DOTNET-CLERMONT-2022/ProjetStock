using AutoMapper;
using ProjectStockEntity;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.Map
{
    public class OrderEntityProfile : Profile
    {
        public OrderEntityProfile()
        {
            CreateMap<OrderEntity, OrderModel>().ReverseMap();
                
        }
    }
}
