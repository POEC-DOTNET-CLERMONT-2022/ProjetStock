using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockDTOS
{
    public class MarketDto
    {
        [Key]
        public Guid Id { get; set; }
        public string _name { get; set; }  
        public DateTime _openingDate { get;  set; }
        public DateTime _closingDate { get;  set; }
        public List<Stock> _stocks { get; set; }
    }
}
