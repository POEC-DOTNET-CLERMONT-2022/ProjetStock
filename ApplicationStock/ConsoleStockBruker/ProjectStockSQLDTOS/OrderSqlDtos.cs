using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockSQLDTOS
{
    [Table("Order")]
    public sealed class OrderSqlDtos : IEquatable<OrderSqlDtos>
    {
        [Key]

        public Guid _id { get; private set; }

        public string _orderName { get; set; }

        public DateTime _orderDate { get; set; }

        private Stock _stock { get; set; }

        public int _nbStock { get; set; }

        public OrderSqlDtos(string orderName, int nbStock)
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            _id = Guid.NewGuid();
            _stock = new Stock();
            _nbStock = nbStock;
        }
        public bool Equals(OrderSqlDtos? other)
        {
            if (other == null) return false;
            return true;
        }

    }
}
