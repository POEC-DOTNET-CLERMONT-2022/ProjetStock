using ProjectStockSQLDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository
{
    public class StockSqlRepository
    {

        private SqlDbContext SqlContext { get; }

        public StockSqlRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public StockSqlDtos? Add(StockSqlDtos stockSqlDto)
        {
            StockSqlDtos entity = SqlContext.Add(stockSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public StockSqlDtos? Update(StockSqlDtos stockSqlDto)
        {
            StockSqlDtos? entity = GetSingle(stockSqlDto._id);
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
            StockSqlDtos? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<StockSqlDtos>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public StockSqlDtos? GetSingle(Guid id)
        {
            return SqlContext.Set<StockSqlDtos>()
                             .SingleOrDefault(stock => stock._id == id);
        }


    }

}
