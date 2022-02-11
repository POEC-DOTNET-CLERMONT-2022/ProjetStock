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
        public Guid Id { get; set; }
        public string? _firstName { get; set; }
        public string? _lastName { get; set; }
        public string? _email { get; set; }
        public string? _phone { get; set; }
        public string? _siret { get; set; }
        public string? _password { get; set; }
        public string? _token { get; set; }
        public DateTime? _expireToken { get; set; }
        public List<Address> _addresses { get; set; }
        public List<Stock> _stocks { get; set; }


    }
}