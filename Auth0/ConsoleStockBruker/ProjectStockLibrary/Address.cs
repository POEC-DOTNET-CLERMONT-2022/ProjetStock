using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectStockLibrary
{
    [JsonArray]
    public class Address : BaseEntity
    {
        [MaxLength(200)]
        public string _address_line_1 { get; set; }
        [MaxLength(200)]
        public string _address_line_2 { get;  set; }
        [MaxLength(6)]
        public string _codePostal { get;set; }
        [MaxLength(200)]
        public string _city { get; set; }
        [MaxLength(50)]
        public string _country { get; set; }


        public Guid ClientId { get; set; }

        public Address(string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
             Id = Guid.NewGuid();
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }
        public Address(Guid id ,string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
            Id = id;
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }

        public Address(Guid _id)
        {
            Id = Guid.NewGuid();
            _address_line_1 = "";
            _address_line_2 = "";
            _codePostal = "";
            _city = "";
            _country = "";

        }


        public Address()
        {
            Id = Guid.NewGuid() ;
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
