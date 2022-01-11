using ProjectStockSQLDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository
{
   public class UserSqlRepository
    {
        private SqlDbContext SqlContext { get; }

        public UserSqlRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public UserSqlDtos? Add(UserSqlDtos userSqlDto)
        {
            UserSqlDtos entity = SqlContext.Add(userSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public UserSqlDtos? Update(UserSqlDtos userSqlDto)
        {
            UserSqlDtos? entity = GetSingle(userSqlDto._id);
            if (entity == null)
            {
                return null;
            }
        
            entity._phone = userSqlDto._phone;
            entity._email = userSqlDto._email;
            entity._siret = userSqlDto._siret;
            entity._lastName = userSqlDto._lastName;
            entity._firstName = userSqlDto._firstName;
            

            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            UserSqlDtos? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<UserSqlDtos>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public UserSqlDtos? GetSingle(Guid id)
        {
            return SqlContext.Set<UserSqlDtos>()
                             .SingleOrDefault(user => user._id == id);
        }

         
    }
}
