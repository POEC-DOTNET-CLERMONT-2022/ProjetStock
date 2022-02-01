using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace ProjectStockLibrary
{
    [DataContract]
    public class Client
    {
        [Key]
        [JsonProperty(PropertyName = "_id")]
        public  Guid _id { get; private set; }
        [JsonProperty(PropertyName = "_firstName")]
        public string _firstName { get;  set; }
        [JsonProperty(PropertyName = "_lastName")]
        public string _lastName { get; set; }
        [JsonProperty(PropertyName = "_email")]
        public string _email { get; set; }
        [JsonProperty(PropertyName = "_phone")]
        public string _phone { get;  set; }
        [JsonProperty(PropertyName = "_siret")]
        public string _siret { get;  set; }

 
        [JsonProperty(PropertyName = "_token")]
        public string? _token { get; set; } = null;

        [JsonProperty(PropertyName = "_expireToken")]
        public DateTime? _expireToken { get; set; } = null;


        [JsonProperty(PropertyName = "_password")]
        public string _password { get; set; }

       // [ForeignKey("Address")]
        [JsonProperty(PropertyName = "_addresses")]
        [JsonConverter(typeof(List<Address>))]
        public List<Address> _addresses { get; private set; }

       // [ForeignKey("Stock")]

        [JsonProperty("_stocks")]
        [JsonConverter(typeof(List<Stock>))]
        private List<Stock>? _stocks { get; set; }


        [JsonConstructor]
        public Client(string firstName, string lastName, string email, string phone, string siret, string password, List<Address> addresses, List<Stock>? stocks)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 || siret is null ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 || phone is null ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = addresses;
            _stocks = stocks;
            _password = password;



        }

        public Client(string firstName, string lastName, string email, string phone, string siret ,List<Address> addresses, List<Stock>? stocks)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 || siret is null ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 || phone is null ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = addresses;
            _stocks = stocks;
            _password = "";



        }

      

        public Client(string firstName , string lastName, string email, string phone, string siret)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 || siret is null ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 || phone is null ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = new List<Address>();
            _stocks = new List<Stock>();
            _password = "";
            


        }
       
        public Client(string firstName, string lastName, string email, string phone, string siret, string password)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 || siret is null ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 || phone is null ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = new List<Address>();
            _stocks = new List<Stock>();
            _password = password;



        }
        public Client(Guid id, string firstName , string lastName, string email, string phone, string siret) : this(firstName, lastName, email, phone, siret)
        {
            _id = id;
            
        }



        public Client(Guid _id)
        {
            _id = _id;
            _firstName = "";
            _lastName = "";
            _email = "";
            _siret = "";
            _phone = "";
            _addresses = new List<Address>();
            _stocks = new List<Stock>();
            _password = "";
        }
        public Client()
        {
            _id = Guid.NewGuid();
            _firstName = "";
            _lastName = "";
            _email = "test@test.fr";
            _siret = "";
            _phone = "";
            _addresses = new List<Address>();
            _stocks = new List<Stock>();
            _password = "";
        }


        public void setToken(string token)
        {
            _token = token;
        }

        public void setStocks(List<Stock> _list)
        {
            this._stocks = _list;
        }


        public void setAddress(List<Address> _list)
        {
            this._addresses = _list;
        }

        public void setExpireDate(DateTime date)
        {
            _expireToken = date ;
        }
        public void AddAdress(Address address)
        {
            if (!_addresses.Contains(address))
            {
                _addresses.Add(address);
            }
            else
            {
                throw new Exception("Is already add");
            }
            
        }

        public void removeAdress(Address address)
        {
            if (_addresses.Contains(address))
            {
                _addresses.Remove(address);
            }
            else
            {
                throw new ArgumentException("Not address correpond to your address");
            }
           
        }
        public void AddStocks(Stock stock)
        {
            if (!_stocks.Contains(stock))
            {
                _stocks.Add(stock);
            }
            else
            {
                throw new ArgumentException("Not address correpond to your address");
            }

        }

        public void removeStocks(Stock stock)
        {
            if (_stocks.Contains(stock))
            {
                _stocks.Remove(stock);
            }
            else
            {
                throw new ArgumentException("Not address correpond to your address");
            }

        }


        public string readAllMyStock()
        {
            string maString = "";
            foreach (Stock stock in _stocks)
            {
                maString += stock.read();
            }

            return maString;
        }



        public void modifyAdress(int i,string firstName,string lastName,string email,string phone,string siret)
        {
            
        }
        

        public string readAllMyAdress()
        {
            string maString = "";
            foreach(Address address in _addresses)
            {
                maString += address.read();
            }

            return maString;
        }
      

        


    }
}