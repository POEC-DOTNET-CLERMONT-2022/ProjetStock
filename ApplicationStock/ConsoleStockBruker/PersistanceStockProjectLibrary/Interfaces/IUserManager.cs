using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersistanceStockProjectLibrary.Interfaces
{
    public interface IUserManager
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUser(int id);
        IEnumerable<Client> GetUsers();
        void Update(int id, UserDto userDto);
        void Add(UserDto userDto);
        void Delete(UserDto userDto);
       
    }
}
