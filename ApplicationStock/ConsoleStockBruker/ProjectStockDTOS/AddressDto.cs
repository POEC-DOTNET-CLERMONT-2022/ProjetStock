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
        [DataMember]
        [Required]
        public Guid _id { get;  set; }
        [DataMember]
        [Required]
        public string? _address_line_1 { get; set; }
        [DataMember]
        public string? _address_line_2 { get; set; }
        [DataMember]
        [Required]
        public string? _codePostal { get;  set; }
        [DataMember]
        [Required]
        public string? _city { get; set; }
        [DataMember]
        [Required]
        public string? _country { get; set; }
    }
}
