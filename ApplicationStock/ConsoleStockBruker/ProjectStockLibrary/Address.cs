﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectStockLibrary
{
    [JsonArray]
    public class Address
    {
        [Key]
        [JsonProperty(PropertyName = "_id")]
        public Guid _id { get; private set; }
        [JsonProperty(PropertyName = "_address_line_1")]
        public string _address_line_1 { get; set; }
        [JsonProperty(PropertyName = "_address_line_2")]
        public string _address_line_2 { get;  set; }
        [JsonProperty(PropertyName = "_codePostal")]
        public string _codePostal { get;set; }

        [JsonProperty(PropertyName = "_city")]
        public string _city { get; set; }

        [JsonProperty(PropertyName = "_country")]
        public string _country { get; set; }

       [JsonConstructorAttribute]
        public Address(string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
             _id = Guid.NewGuid();
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }
        public Address(Guid id ,string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
            _id = id;
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }

        public Address(Guid _id)
        {
            _id = Guid.NewGuid();
            _address_line_1 = "";
            _address_line_2 = "";
            _codePostal = "";
            _city = "";
            _country = "";

        }


        public Address()
        {
            _id = Guid.NewGuid() ;
            _address_line_1 = "";
            _address_line_2 = "";
            _codePostal = "";
            _city = "";
            _country = "";

        }


        public string read()
        {
            return $"adress_ : {_address_line_1} adress_ : {_address_line_2} codePostal :{ _codePostal} city : { _city} country : { _country}";
        }


         
    }
    
}
