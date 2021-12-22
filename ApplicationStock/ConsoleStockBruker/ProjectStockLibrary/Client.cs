namespace ProjectStockLibrary
{
     internal class Client
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _siret;
        private Address _address;

        public Client(string firstName , string lastName, string email, string phone, string siret, Address address)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;                  
            _email = email;
            _siret = siret;
            _phone = phone;
            _address = address;


        }
        public Client(Guid id, string firstName , string lastName, string email, string phone, string siret, Address address) : this(firstName, lastName, email, phone, siret, address)
        {
            _id = id;
        }

    }
}