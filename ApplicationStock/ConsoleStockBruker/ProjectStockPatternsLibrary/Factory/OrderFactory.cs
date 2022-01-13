using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStockPatternsLibrary.Factory
{
    public static class OrderFactory
    {
        public static IEnumerable<OrderDto> ToDto(this IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                yield return order.ToDto();
            }
        }

        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto() {_id = order._id,_nbStock = order._nbStock,_orderDate = order._orderDate,_orderName=order._orderName };
        }

        public static IEnumerable<Order> ToDto(this IEnumerable<OrderDto> orders)
        {
            foreach (var order in orders)
            {
                yield return order.ToModel();
            }
        }

        public static Order ToModel(this OrderDto order)
        {
            return new Order(order._orderName,order._stock,order._nbStock,order._orderDate);
        }
    }
}
