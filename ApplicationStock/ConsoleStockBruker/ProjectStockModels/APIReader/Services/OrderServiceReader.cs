using AutoMapper;
using ProjectStockDTOS;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Services
{
    public class OrderServiceReader : JsonGenericReader<OrderModel, OrderDto>
    {


        public OrderServiceReader(HttpClient httpClient, IMapper mapper) : base(httpClient, "api/Order", mapper)
        {

        }



    }
}
