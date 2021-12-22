using System.Text.RegularExpressions;

namespace ProjectStockLibrary
{
     internal class Client 
    {
        private Guid _id;
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _email { get; set; }
        private string _phone { get; set; }
        private string _siret { get; set; }
        private List<Address> _addresses;

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


        }
        public Client(Guid id, string firstName , string lastName, string email, string phone, string siret) : this(firstName, lastName, email, phone, siret)
        {
            _id = id;
            
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
                throw new Exception("Not address correpond to your address");
            }
           
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