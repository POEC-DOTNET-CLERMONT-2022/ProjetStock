using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;
using MyStockModels;

namespace ConsoleStockBruker
{
    internal class ConsoleWriterStocks : IWriterStock
    {
        public void Display(string s)
        {
            Console.WriteLine(s);
        }

       

        public void DisplayAll(Stock stock)
        {
            string maString = "";
            maString += $"Name {stock._name} value: {stock._value } entrerprise :{stock._entrepriseName}";
            Console.WriteLine(maString);
        }
    }
}
