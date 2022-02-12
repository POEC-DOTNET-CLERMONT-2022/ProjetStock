using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace ProjectStockDTOS
{
    public class CryptoDto
    {
        public Guid Id {get; private set;}
        public string? _name {get; set;}
        public float _value{get; set;}
        public List<Client>? _listClient {get; set;}
        public List<Market>? _listMarker {get; set;}

    }
}


