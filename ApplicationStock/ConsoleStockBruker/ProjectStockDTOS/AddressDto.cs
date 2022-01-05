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
    public class AddressDto
    {
        [DataMember]
        [Required]
        private Guid _id;
        [DataMember]
        public string _address_line_1 { get; set; }
        [DataMember]
        public string _address_line_2 { get; private set; }
        [DataMember]    
        public string _codePostal { get; private set; }
        [DataMember]
        public string _city { get; private set; }
        [DataMember]     
        public string _country { get; private set; }
    }
}
