using System.Text.RegularExpressions;

namespace ProjectStockLibrary
{
    public class Client 
    {
        private Guid _id;
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public string _email { get; private set; }
        public string _phone { get; private set; }
        public string _siret { get; private set; }
        private List<Address> _addresses;

        private List<Stock> _stocks;

        public Client(string firstName , string lastName, string email, string phone, string siret)
        {
            _id = Guid.NewGuid();
            _firstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            _lastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            _email = !regex.IsMatch(email) ? throw new Exception(nameof(email)) : email;
            _siret = string.IsNullOrEmpty(siret) && siret.Length < 14 ? throw new ArgumentNullException(nameof(siret)) : siret;
            _phone = string.IsNullOrEmpty(phone) && phone.Length < 12 ? throw new ArgumentNullException(nameof(phone)) : phone;
            _addresses = new List<Address>();
            _stocks = new List<Stock>();


        }
        internal Client(Guid id, string firstName , string lastName, string email, string phone, string siret) : this(firstName, lastName, email, phone, siret)
        {
            _id = id;
            
        }

        private void AddAdress(Address address)
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

        private void removeAdress(Address address)
        {
            if (_addresses.Contains(address))
            {
                _addresses.Remove(address);
            }
            else
            {
                throw new Exception("Not address correpond to your address");
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
                throw new Exception("Is already add this ");
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
                throw new Exception("Not address correpond to your address");
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



        public void modifyAdress(string firstName,string lastName,string email,string phone,string siret)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _siret = siret;
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