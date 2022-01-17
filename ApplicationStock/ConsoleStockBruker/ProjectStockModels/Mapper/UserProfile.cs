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
   public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserEntity,UserModel>().ReverseMap();
        }
      
    }
}
