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
        //TODO : inutile 
        [JsonProperty("_id")]
        public Guid _id { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("_firstName")]
        public string? _firstName { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("_lastName")]
        public string? _lastName { get; set; }
        [DataMember]
        [JsonProperty("_email")]
        public string? _email { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("_phonee")]
        public string? _phone { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("_siret")]
        public string? _siret { get; set; }
        
        [DataMember]
        [Required]
        [JsonProperty("_password")]
        public string? _password { get; set; }

        [JsonIgnore]
        [DataMember]
        [JsonProperty("_token")]
        public string? _token { get; set; }

        [JsonIgnore]
        [DataMember]
        [JsonProperty("_expireToken")]

        public DateTime? _expireToken { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("_addresses")]
        public List<Address> _addresses { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("_stocks")]
        public List<Stock> _stocks { get; set; }


    }
}