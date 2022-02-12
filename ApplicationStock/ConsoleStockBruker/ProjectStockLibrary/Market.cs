using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Market : BaseEntity
    {
        [Key]
        public new Guid Id { get; set; }
        public string _name {  get;  set; }
        public DateTime _openingDate {  get;  set; }
        public  DateTime _closingDate { get; set; }
        [ForeignKey("Stock")]

        public List<Stock> _stock { get; set; }
        
        public Market(string name, DateTime closingDate , DateTime openingDate)
        {
            Id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _openingDate = openingDate;
            _closingDate = closingDate;
            _stock = new List<Stock>();

        }


        public Market(string name)
        {
            Id = Guid.NewGuid();
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
