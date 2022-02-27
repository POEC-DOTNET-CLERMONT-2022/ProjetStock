using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ProjectStockLibrary;

namespace ProjectStockDTOS
{
    //TODO : inutile pour REST 
    [DataContract]
    public class StockDto
    {
 
        public Guid Id { get; set; }
        public string? _name { get; set; }
        public float _value { get; set; }
        public string? _entrepriseName { get; set; }
        public Guid? ClientId { get; set; }
        private  List<Client>? _clients { get; set; }
    }
}