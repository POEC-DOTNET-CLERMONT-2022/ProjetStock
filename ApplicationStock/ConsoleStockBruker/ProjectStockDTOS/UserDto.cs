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
    [DataContract]
    public class UserDto
    {
        [DataMember]
        [Required]
        public Guid _id { get; set; }
        [DataMember]
        [Required]
        public string _firstName { get; set; }
        [DataMember]
        [Required]
        public string _lastName { get; set; }
        [DataMember]
       
        public string _email { get; set; }
        [DataMember]
        [Required]
        public string _phone { get; set; }
        [DataMember]
        [Required]
        public string _siret { get; set; }
        [DataMember]
        [Required]
        public List<Address> _addresses { get; set; }
    }
}