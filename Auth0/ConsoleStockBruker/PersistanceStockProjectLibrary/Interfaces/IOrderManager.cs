using ProjectStockDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceStockProjectLibrary.Interfaces
{
    public interface IOrderManager
    {

        IEnumerable<OrderDto> GetOrders();

        OrderDto GetById(int id);


        void add(OrderDto userDto);

     
        void delete(OrderDto userDto);
    }
}
