using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;


namespace ProjectStockLibrary
{
    public class Stock
    {
        private Guid _id { get; set; }
        public string _name { get; set; }
        private float _value { get; set; }
        public string _entrepriseName { get; set; }
        private List<Client> _clients { get; set; }
        


        public Stock(string name,float value, string entrepriseName)
        {
            _id = Guid.NewGuid();
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _value = value < 0 ? throw new Exception(nameof(_value)) : value;
            _entrepriseName = string.IsNullOrEmpty(entrepriseName) ? throw new ArgumentNullException(nameof(entrepriseName)) : entrepriseName;
            _clients = new List<Client>();
        }

        public string read()
        {
            return $"name : {_name} value : {_value} entrepriseName :{ _entrepriseName}";
        }

    }
}
