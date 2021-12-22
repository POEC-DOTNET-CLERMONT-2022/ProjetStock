using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Market 
    {
        private Guid _id { get; set; }
        private string _name { get; set; }
        private DateTime _openingDate { get; set; }
        private DateTime _closingDate { get; set; }

        private List<Stock> _stock { get; set; }
        
        public Market(string name, DateTime closingDate , DateTime openingDate,)
        {
            _id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _openingDate = openingDate;
            _closingDate = closingDate;
            _stock = new List<Stock>();

        }


        public Market(string name)
        {
            _id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _openingDate = DateTime.Now;
            _closingDate = DateTime.Now;
            _stock = new List<Stock>();
        }

  

    }
}
