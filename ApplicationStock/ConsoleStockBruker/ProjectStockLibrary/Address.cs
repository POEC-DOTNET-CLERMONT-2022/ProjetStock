using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    internal class Address
    {
        private Guid _id;
        private string _address_line_1 { get; set; }
        private string _address_line_2 { get; set; }
        private string _codePostal { get; set; }
        private string _city { get; set; }
        private string _country { get; set; }
      
        public Address(string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
             _id = Guid.NewGuid();
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }


        public string read()
        {
            return $"adress_ : {_address_line_1} adress_ : {_address_line_2} codePostal :{ _codePostal} city : { _city} country : { _country}";
        }


         
    }
    
}
