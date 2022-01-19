using ProjectStockDTOS;
using ProjectStockModels.APIReader.Interfaces;
using ProjectStockModels.JsonReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Services
{
    internal class UserServiceReader : JsonGenericReader<UserModel, UserDto>,IUserService
    {
    

        public UserServiceReader(HttpClient httpClient) : base(httpClient,"api/User")
        {

        }



    }
}
