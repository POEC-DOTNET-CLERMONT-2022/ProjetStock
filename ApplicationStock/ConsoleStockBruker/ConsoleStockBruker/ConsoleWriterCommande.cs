using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;
using MyStockModels;

namespace ConsoleStockBruker
{
    internal class ConsoleWriterCommande : IWriterCommande
    {

        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        public void DisplayAll(Order order)
        {
            string maString = "";
            maString += $"Name {order._orderName} date :{order._orderDate} nb :{order._nbStock}";
            Console.WriteLine(maString);
          
        }
    }
}
