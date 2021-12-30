using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;
using ProjectStockLibrary;

namespace ConsoleStockBruker
{
    internal class ConsoleReaderMarket :IReaderMarket
    {
        public IWriterMarket Writer { get; set; }

     

        public Market create()
        {
            Writer.Display("Donne moi le nom du market");
            var Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }
           

            return new Market(Name);
        }
    }
}
