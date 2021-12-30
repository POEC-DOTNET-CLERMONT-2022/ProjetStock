using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace ConsoleStockBruker
{
    internal class ConsoleWriterMarket  : IWriterMarket
    {
        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        public void DisplayAll(Market market)
        {
            string maString = "";
            maString += $"Name { market._name} openingDate : {market._openingDate} endDate : {market._closingDate}";
            Console.WriteLine(maString);
            
        }
    }
}
