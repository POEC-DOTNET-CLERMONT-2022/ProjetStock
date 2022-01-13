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
    [Table("Market")]
    public sealed class MarketEntity : IEquatable<MarketEntity>
    {
        [Key]

        public Guid _id { get; private set; }

        public string _name { get; set; }

        public DateTime _openingDate { get; set; }

        public DateTime _closingDate { get; set; }


        [ForeignKey("Market")]
        public List<Stock> _stocks { get; set; }

        public MarketEntity(string name, DateTime closingDate, DateTime openingDate)
        {
            _id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _openingDate = openingDate;
            _closingDate = closingDate;
            _stocks = new List<Stock>();

        }
        public bool Equals(MarketEntity? other)
        {
            if (other == null) return false;
            return true;
        }
    }
}
