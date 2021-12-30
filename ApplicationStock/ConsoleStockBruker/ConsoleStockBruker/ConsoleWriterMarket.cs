using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;
using MyStockModels;

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

        public void DisplayAllStocksOfMarket(List<Stock> _stocks)
        {
            string maString = "";
            foreach (Stock stock in _stocks)
            {
                maString += $"Name {stock._name}  entrepriseName {stock._entrepriseName} value : {stock._value }" + "\n";
            }
            Console.WriteLine(maString);
        }
    }
}
