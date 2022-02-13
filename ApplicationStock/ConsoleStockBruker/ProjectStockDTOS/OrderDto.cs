using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace ProjectStockDTOS
{
    
   public class OrderDto
    {
        public Guid Id { get; set; }
        public string? _orderName { get;  set; }
        public DateTime _orderDate { get; set; }

        public Guid ClientId { get; set; }
        public Stock? _stock { get; set; }
        public int _nbStock { get;  set; }
    }
}
