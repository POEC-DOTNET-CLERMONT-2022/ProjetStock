using System.ComponentModel.DataAnnotations;

namespace ProjectStockLibrary { 


public class Crypto
    {
        [Key]
        public Guid _id { get; private set; }
        public string _name { get; set; }

        public float _value { get; set; }


        public List<Client> _listClient { get; set; }

        public List<Market> _listMarket { get; set; }

        public Crypto(Guid id, string name, float value)
        {
            _id = id;
            _name = name;
            _value = value;
            _listClient = new List<Client>();
            _listMarket = new List<Market>();
        }

        public Crypto(Guid id)
        {
            _id = id;
            _name = "name";
            _value = 0;
            _listClient = new List<Client>();
            _listMarket = new List<Market>();
        }


    }
}


