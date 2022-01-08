using AutoFixture;
using PersistanceStockProjectLibrary.Interfaces;
using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceStockProjectLibrary.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly Fixture _fixture = new Fixture();
        private List<OrderDto> orders { get; set; } = new List<OrderDto>();



    
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDto> GetOrders()
        {
            var creatures = new List<Order>() { new Order("mon_order",5) };

            foreach (var creature in creatures)
            {

                yield return new OrderDto() { _id = creature._id,_orderName = creature._orderName , _orderDate = creature._orderDate,_nbStock= creature._nbStock };
            }
        }


        public OrderDto GetById(int id)
        {
            return orders[id];
  
        }


        public void add(OrderDto orderDto)
        {

            try
            {
                orders.Add(orderDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }

        }

        public void delete(OrderDto orderDto)
        {
            try
            {
                orders.Remove(orderDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}
