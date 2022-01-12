using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface IUserRepository
    {

        UserEntity? Add(UserEntity userSqlDto);

        UserEntity? Update(UserEntity userSqlDto);
      

        bool Delete(Guid id);
       

        UserEntity? GetSingle(Guid id);
      
    }
}
