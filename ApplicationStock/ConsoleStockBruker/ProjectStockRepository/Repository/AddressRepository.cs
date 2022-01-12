using ProjectStockEntity;
using ProjectStockRepository.Context;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Repository
{
    internal class AddressRepository : IAddressRepository
    {
        private SqlDbContext SqlContext { get; }

        public AddressRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public AddressEntity? Add(AddressEntity addressEntity)
        {
            AddressEntity entity = SqlContext.Add(addressEntity).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public AddressEntity? Update(AddressEntity addressEntity)
        {
            AddressEntity? entity = GetSingle(addressEntity._id);
            if (entity == null)
            {
                return null;
            }


         
         
            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            AddressEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<AddressEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public AddressEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<AddressEntity>()
                             .SingleOrDefault(address => address._id == id);
        }
    }
}
