using ProjectStockEntity;
using ProjectStockRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockRepository.Interfaces;

namespace ProjectStockRepository 
{
    public class StockRepository : IStockRepository
    {

        private SqlDbContext SqlContext { get; }

        public StockRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public StockEntity? Add(StockEntity stockSqlDto)
        {
            StockEntity entity = SqlContext.Add(stockSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public StockEntity? Update(StockEntity stockSqlDto)
        {
            StockEntity? entity = GetSingle(stockSqlDto._id);
            if (entity == null)
            {
                return null;
            }

            entity._value = stockSqlDto._value;
            entity._entrepriseName = stockSqlDto._entrepriseName;
            entity._name = stockSqlDto._name;
            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            StockEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<StockEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public StockEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<StockEntity>()
                             .SingleOrDefault(stock => stock._id == id);
        }


    }

}
