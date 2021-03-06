using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectStockEntity
{
    [Table("Crypto")]
    public sealed class CryptoEntity:IEquatable<CryptoEntity>
    {
        [Key]
        public Guid Id {get; private set;}
        public string? _name {get; set;}
        
        public float _value {get; set;}

        public  ICollection<Client>? _listClient { get; set; }
        


        public List<Market>? _listMarket {get; set;}

        public bool Equals(CryptoEntity? other)
        {
            if (other == null) return false;
            return true;
        }
    }

}