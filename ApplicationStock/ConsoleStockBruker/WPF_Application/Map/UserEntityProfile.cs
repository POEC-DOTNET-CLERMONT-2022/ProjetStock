using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStockEntity;
using ProjectStockModels;
using ProjectStockModels.Model;

namespace WPF_Application.Map
{
   public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserEntity,UserModel>().ReverseMap();
            CreateMap<Client,UserModel>().ReverseMap();
        }
      
    }
}
