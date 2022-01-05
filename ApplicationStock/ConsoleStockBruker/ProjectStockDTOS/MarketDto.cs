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
    [DataContract]
    internal class MarketDto
    {
        [DataMember]
        [Required]
        private Guid _id;
        [DataMember]
        [Required]
        public string _name { get; private set; }
        [DataMember]
        [Required]
        public DateTime _openingDate { get; private set; }
        [DataMember]
        [Required]
        public DateTime _closingDate { get; private set; }
        [DataMember]
        [Required]
        public List<Stock> _stock { get; set; }
    }
}
