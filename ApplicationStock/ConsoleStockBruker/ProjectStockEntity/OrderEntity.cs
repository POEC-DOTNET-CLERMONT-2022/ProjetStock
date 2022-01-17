using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockEntity
{
    [Table("Order")]
    public sealed class OrderEntity : IEquatable<OrderEntity>
    {
        [Key]

        public Guid _id { get; private set; }

        public string _orderName { get; set; }

        public DateTime _orderDate { get; set; }

        [ForeignKey("Stock")]
        public Stock _stock { get; set; }

        public int _nbStock { get; set; }

        public OrderEntity(string orderName, int nbStock)
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            _id = Guid.NewGuid();
            _stock = new Stock();
            _nbStock = nbStock;
        }
        public bool Equals(OrderEntity? other)
        {
            if (other == null) return false;
            return true;
        }

    }
}
