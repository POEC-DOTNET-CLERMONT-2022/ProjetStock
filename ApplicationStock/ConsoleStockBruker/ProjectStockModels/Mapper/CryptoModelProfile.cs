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
    internal class CryptoModelProfile : Profile
    {
        public CryptoModelProfile()
        {
            CreateMap<CryptoModel, Crypto>().ReverseMap();
        }
    }
}
