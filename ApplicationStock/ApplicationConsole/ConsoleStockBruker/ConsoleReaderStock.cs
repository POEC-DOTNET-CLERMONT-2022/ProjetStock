using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;
using MyStockModels;

namespace ConsoleStockBruker
{
    internal class ConsoleReaderStock : IReaderStock
    {
        public IWriterStock Writer { get; set; }

        public Stock create()
        {
            Writer.Display("Donne moi le nom de l'action");
            var Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }
            Writer.Display("Donne moi le nom de l'entreprise");
            var entrepriseName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrepriseName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }

            Writer.Display("Donne moi la valeur de l'action");
            var value = float.Parse(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(entrepriseName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }
            

            return new Stock (Name,value,entrepriseName);
        }

    }
}
