using AutoMapper;
using ProjectStockDTOS;
using ProjectStockModels.APIReader.Interfaces;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Services
{
    public class UserServiceReader : JsonGenericReader<UserModel, UserDto> 
    {
    

        public UserServiceReader(HttpClient httpClient,IMapper mapper) : base(httpClient,"api/User",mapper)
        {

        }



    }
}
