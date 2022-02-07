﻿using System;
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
        [DataMember]
        [Required]
  
        public Guid Id { get; set; }
        [DataMember]
        [Required]
        public string? _name { get; set; }
        [DataMember]
        [Required]
        public float _value { get; set; }
        [DataMember]
        [Required]
        public string? _entrepriseName { get; set; }
        [DataMember]
        [Required]
        private List<Client>? _clients { get; set; }
    }
}