using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;
using ProjectStockLibrary;

namespace ConsoleStockBruker
{
    internal class ConsoleWriterClient : IWriterClient
    {
        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        public void DisplayAll(Client client)
        {
            string maString = "";
            maString += $"firstName { client._firstName} lastName : {client._lastName}  email: {client._email} phone : {client._phone} siret : {client._phone}";
            Console.WriteLine(maString);

        }

        public void DisplayAllUserStock(List<Stock> _stocks)
        {
            string maString = "";
            foreach (Stock stock in _stocks)
            {
                maString += $"Name {stock._name}  entrepriseName {stock._entrepriseName} value : {stock._value }" + "\n";
            }
            Console.WriteLine(maString);
        }
        
        public void DisplayAllUserAddress(List<Address> _addresses)
        {
            string maString = "";
            foreach (Address address in _addresses)
            {
                maString += $"Adress 1  { address._address_line_1 }  Adress 2  { address._address_line_2 }  CodePostal  { address._codePostal }  City  { address._city}  Country  { address._country } " + "\n";
            }
            Console.WriteLine(maString);
        }
    }
}
