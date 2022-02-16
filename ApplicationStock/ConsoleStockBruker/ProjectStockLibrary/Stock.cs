using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectStockLibrary;


namespace ProjectStockLibrary
{

    public class Stock : BaseEntity
    {
    
        public string _name { get;  set; }
        public float _value { get;  set; }
        public string _entrepriseName { get;set; }

        public Guid? ClientId { get; set; }
        private List<Client> _clients { get; set; }

        public Stock(string name,float value, string entrepriseName)
        {
            Id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _value = value < 0 ? throw new Exception(nameof(_value)) : value;
            _entrepriseName = string.IsNullOrEmpty(entrepriseName) ? throw new ArgumentNullException(nameof(entrepriseName)) : entrepriseName;
            _clients = new List<Client>();
        }

        public object ToDto()
        {
            throw new NotImplementedException();
        }

        public Stock(Guid _id,string name, float value, string entrepriseName)
        {
            _id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _value = value < 0 ? throw new Exception(nameof(_value)) : value;
            _entrepriseName = string.IsNullOrEmpty(entrepriseName) ? throw new ArgumentNullException(nameof(entrepriseName)) : entrepriseName;
            _clients = new List<Client>();
        }


        public Stock()
        {
            Id = Guid.NewGuid();
            _name = "";
            _value = 0;
            _entrepriseName = "";
            _clients = new List<Client>();
        }


        public string read()
        {
            return $"name : {_name} value : {_value} entrepriseName :{ _entrepriseName}";
        }

    }
}
