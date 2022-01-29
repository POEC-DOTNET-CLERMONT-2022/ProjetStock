using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ProjectStockDTOS
{
    
   public class OrderDto
    {
        [DataMember]
        [Required]
        public Guid _id { get; set; }
        [DataMember]
        [Required]
        public string? _orderName { get;  set; }
        [DataMember]
        [Required]
        public DateTime _orderDate { get; set; }
        [DataMember]
        [Required]
        public Stock? _stock { get; set; }
        [DataMember]
        [Required]
        public int _nbStock { get;  set; }
    }
}
