using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStockEntity;

namespace ProjectStockModels.Mapper
{
   public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<UserModel,Client>().ReverseMap();
        }
      
    }
}
