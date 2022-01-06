using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
     public  class Address
    {
        public Guid _id { get; set; }
        public string _address_line_1 { get; private set; }
        public string _address_line_2 { get; private set; }
        public string _codePostal { get; private set; }
        public string _city { get; private set; }
        public string _country { get; private set; }

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
