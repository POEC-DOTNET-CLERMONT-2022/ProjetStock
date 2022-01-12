using ProjectStockSQLDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository
{
    public class MarketSqlRepository
    {
        private SqlDbContext SqlContext { get; }

        public MarketSqlRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public MarketSqlEntity? Add(MarketSqlEntity marketSqlDto)
        {
            MarketSqlEntity entity = SqlContext.Add(marketSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public  MarketSqlEntity? Update(MarketSqlEntity marketSqlDto)
        {
            MarketSqlEntity? entity = GetSingle(marketSqlDto._id);
            if (entity == null)
            {
                return null;
            }

           
            entity._name = marketSqlDto._name;
            entity._openingDate = marketSqlDto._openingDate;
            entity._stocks = marketSqlDto._stocks;
            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            MarketSqlEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<MarketSqlEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public MarketSqlEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<MarketSqlEntity>()
                             .SingleOrDefault(market => market._id == id);
        }
    }
}
