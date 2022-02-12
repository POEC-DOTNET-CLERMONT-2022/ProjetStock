using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockDTOS
{ 
    public class AddressDto
    {
        public Guid Id { get;  set; }
        public string? _address_line_1 { get; set; }
        public string? _address_line_2 { get; set; }
        public string? _codePostal { get;  set; }
        public string? _city { get; set; }
        public string? _country { get; set; }

    }
}
