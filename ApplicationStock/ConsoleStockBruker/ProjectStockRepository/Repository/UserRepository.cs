using ProjectStockEntity;
using ProjectStockRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockRepository.Interfaces;

namespace ProjectStockRepository.Repository
{
   public class UserRepository : IUserRepository
    {
        private SqlDbContext SqlContext { get; }

        public UserRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public UserEntity? Add(UserEntity userSqlDto)
        {
            UserEntity entity = SqlContext.Add(userSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public UserEntity? Update(UserEntity userSqlDto)
        {
            UserEntity? entity = GetSingle(userSqlDto._id);
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
            UserEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<UserEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public UserEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<UserEntity>()
                             .SingleOrDefault(user => user._id == id);
        }

         
    }
}
