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
        private string _address_line_1;
        private string _address_line_2;
        private string _codePostal;
        private string _city;
        private string _country;
        public Address(string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
             _id = Guid.NewGuid();
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }
         
    }
    
}
