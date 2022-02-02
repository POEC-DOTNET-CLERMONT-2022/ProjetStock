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
        [DataMember]
        [Required]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public string _name { get; set; }
        [DataMember]
        [Required]
        public DateTime _openingDate { get;  set; }
        [DataMember]
        [Required]
        public DateTime _closingDate { get;  set; }
        [DataMember]
        [Required]
        public List<Stock> _stocks { get; set; }
    }
}
