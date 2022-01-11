using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockSQLDTOS
{ 
    [Table("Address")]
    public class AddressSqlDtos : IEquatable<AddressSqlDtos>
    {
        [Key]
        public Guid _id { get; private set; }
      
        public string _address_line_1 { get; set; }
     
        public string _address_line_2 { get; set; }
     
        public string _codePostal { get; set; }
      
        public string _city { get; set; }

        public string _country { get; set; }


        public AddressSqlDtos(string address_line_1, string address_line_2, string codePostal, string city, string country)
        {
            _id = Guid.NewGuid();
            _address_line_1 = address_line_1;
            _address_line_2 = address_line_2;
            _codePostal = codePostal;
            _city = city;
            _country = country;
        }
        public bool Equals(AddressSqlDtos? other)
        {
            if (other == null) return false;
            return true;
        }
    }
}
