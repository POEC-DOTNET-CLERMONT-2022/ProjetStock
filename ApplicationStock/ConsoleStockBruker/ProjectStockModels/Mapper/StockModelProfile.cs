using AutoMapper;
using ProjectStockLibrary;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Mapper
{
    public class StockModelProfile : Profile
    {
        public StockModelProfile()
        {
       
                CreateMap<StockModel,Stock>().ReverseMap();
         }
    }
}
