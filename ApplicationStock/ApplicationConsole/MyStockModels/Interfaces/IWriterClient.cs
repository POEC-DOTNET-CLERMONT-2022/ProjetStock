using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockModels
{
    public  interface IWriterClient
    {
        void Display(string s);

        void DisplayAll(Client item);

        void DisplayAllUserStock(List<Stock> _stocks);

       void DisplayAllUserAddress(List<Address> adresses);
    }
}
