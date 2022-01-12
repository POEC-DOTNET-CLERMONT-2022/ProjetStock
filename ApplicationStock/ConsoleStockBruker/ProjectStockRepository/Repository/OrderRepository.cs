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
    public class OrderRepository : IOrderRepository
    {
        private SqlDbContext SqlContext { get; }

        public OrderRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public OrderEntity? Add(OrderEntity OrderSqlDto)
        {
            OrderEntity entity = SqlContext.Add(OrderSqlDto).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public OrderEntity? Update(OrderEntity OrderSqlDto)
        {
            OrderEntity? entity = GetSingle(OrderSqlDto._id);
            if (entity == null)
            {
                return null;
            }


            entity._orderName = OrderSqlDto._orderName;
            entity._orderDate = OrderSqlDto._orderDate;
            entity._stock = OrderSqlDto._stock;
            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            OrderEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<OrderEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public OrderEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<OrderEntity>()
                             .SingleOrDefault(market => market._id == id);
        }
    }
}
