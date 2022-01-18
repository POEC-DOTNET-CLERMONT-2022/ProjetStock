using ProjectStockLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProjectStockEntity
{
    [Table("User")]
    public  class UserEntity : IEquatable<UserEntity>
    {
        [Key]
        public Guid _id { get; private set; }
        
        public string _firstName { get; set; }
       
        public string _lastName { get; set; }
        
        public string _email { get; set; }
        
        public string _phone { get; set; }
       
        public string _siret { get; set; }

        public string _password { get; set; }

        [ForeignKey("Address")]
        public List<Address> _addresses { get; set; }

        [ForeignKey("Stock")]
        private List<Stock> _stocks { get; set; }

   

      public bool Equals(UserEntity? other)
        {
            if (other == null) return false;
            return true;
        }

    }
}