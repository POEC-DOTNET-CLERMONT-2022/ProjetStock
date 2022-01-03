using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Market
    {
        private Guid _id;
        public string _name {  get; private set; }
        public DateTime _openingDate {  get; private set; }
        public  DateTime _closingDate { get; private set; }

        private List<Stock> _stock { get; set; }
        
        public Market(string name, DateTime closingDate , DateTime openingDate)
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
        public void setName(string name)
        {
            this._name = name;
        }


    }
}
