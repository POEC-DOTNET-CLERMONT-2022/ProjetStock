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
    public class UserServiceReader : JsonGenericReader<UserModel, UserDto> , IUserService
    {
    

        public UserServiceReader(HttpClient httpClient) : base(httpClient,"api/User")
        {

        }



    }
}
