
using ProjectStockEntity;
using ProjectStockRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Repository
{
    public class MarketRepository : IMarketRepository
    {
        private SqlDbContext SqlContext { get; }

        public MarketRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public MarketEntity? Add(MarketEntity marketSqlDto)
        {
            MarketEntity entity = SqlContext.Add(marketSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public  MarketEntity? Update(MarketEntity marketSqlDto)
        {
            MarketEntity? entity = GetSingle(marketSqlDto._id);
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
            MarketEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<MarketEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public MarketEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<MarketEntity>()
                             .SingleOrDefault(market => market._id == id);
        }
    }
}
