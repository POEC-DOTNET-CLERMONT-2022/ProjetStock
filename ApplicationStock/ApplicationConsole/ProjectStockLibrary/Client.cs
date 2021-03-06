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
        public  Guid _id { get; private set; }
        public string _firstName { get;  set; }
        public string _lastName { get; set; }
        public string _email { get; set; }
        public string _phone { get;  set; }
        public string _siret { get;  set; }

        [JsonIgnore]
        public string? _token { get; set; } = null;

        [JsonIgnore]
        public DateTime? _expireToken { get; set; } = null;

        [JsonIgnore]
        public string _password { get; set; }

        [ForeignKey("Address")]
        public List<Address> _addresses { get; private set; }

        [ForeignKey("Stock")]
        private List<Stock> _stocks { get; set; }

        [JsonConstructorAttribute]
        public Client(string firstName, string lastName, string email, string phone, string siret ,List<Address> addresses, List<Stock> stocks)
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
        [JsonConstructor]
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