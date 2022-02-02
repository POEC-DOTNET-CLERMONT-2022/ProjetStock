using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockEntity;
using ProjectStockModels;
using ProjectStockModels.Model;

namespace WPF_Application.Map
{
    public class MarketEntityProfile : Profile
    {
        public MarketEntityProfile()
        {
            CreateMap<MarketEntityProfile, MarketModel>();
        }
    }
}
