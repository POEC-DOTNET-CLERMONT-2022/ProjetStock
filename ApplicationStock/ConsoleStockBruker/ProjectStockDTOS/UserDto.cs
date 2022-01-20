using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using ProjectStockLibrary;

namespace ProjectStockDTOS
{
  
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
        public string _password { get; set; }

        [JsonIgnore]
        [DataMember]

        public string _token { get; set; }

        //[JsonIgnore]
        //[DataMember]
    
        //public DateTime _expireToken { get; set; }

        [DataMember]
        [Required]
        public List<Address> _addresses { get; set; }

        [DataMember]
        [Required]
        public List<Stock> _stocks { get; set; }


    }
}