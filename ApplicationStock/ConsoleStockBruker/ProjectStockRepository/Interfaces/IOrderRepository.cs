using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface IOrderRepository
    {

        OrderEntity? Add(OrderEntity orderEntity);

        OrderEntity? Update(OrderEntity orderEntity);


        bool Delete(Guid id);


        OrderEntity? GetSingle(Guid id);
    }
}
