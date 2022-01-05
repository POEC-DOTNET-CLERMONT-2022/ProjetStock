using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ProjectStockLibrary;

namespace ProjectStockDTOS
{
    [DataContract]
    public class StockDto
    {
        [DataMember]
        [Required]
        public Guid _id { get; set; }
        [DataMember]
        [Required]
        public string _name { get; set; }
        [DataMember]
        [Required]
        public float _value { get; set; }
        [DataMember]
        [Required]
        public string _entrepriseName { get; set; }
        [DataMember]
        [Required]
        private List<Client> _clients { get; set; }
    }
}