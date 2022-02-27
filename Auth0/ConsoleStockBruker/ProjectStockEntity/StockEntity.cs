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
    [Table("Stock")]
    public  class StockEntity : IEquatable<StockEntity> 
    {
       
        [Key]
        public Guid Id { get; private set; }
        
        public string _name { get; set; }
     
        public float _value { get; set; }
      
        public string _entrepriseName { get; set; }


        [ForeignKey("Client")]
        public List<Client> _clients { get; set; }



        //public StockEntity(string name, float value, string entrepriseName)
        //{
        //    _id = Guid.NewGuid();
        //    _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        //    _value = value < 0 ? throw new Exception(nameof(_value)) : value;
        //    _entrepriseName = string.IsNullOrEmpty(entrepriseName) ? throw new ArgumentNullException(nameof(entrepriseName)) : entrepriseName;
        //    _clients = new List<Client>();
        //}
       
        public bool Equals(StockEntity? other)
        {
            if (other == null) return false;
            return true;
        }

    }
}
