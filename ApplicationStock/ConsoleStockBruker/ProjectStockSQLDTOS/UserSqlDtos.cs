using ProjectStockLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProjectStockSQLDTOS
{
    [Table("User")]
    public  sealed class UserSqlDtos : IEquatable<UserSqlDtos>
    {
        [Key]
        public Guid _id { get; private set; }
        
        public string _firstName { get; set; }
       
        public string _lastName { get; set; }
        
        public string _email { get; set; }
        
        public string _phone { get; set; }
       
        public string _siret { get; set; }
        
        public List<Address> _addresses { get; set; }

        public UserSqlDtos(string firstName, string lastName, string email, string phone, string siret)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = new List<Address>();

        }

        public bool Equals(UserSqlDtos? other)
        {
            if (other == null) return false;
            return true;
        }

    }
}