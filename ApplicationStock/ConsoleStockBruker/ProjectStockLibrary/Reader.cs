using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;

namespace ProjectStockLibrary
{
    public class Reader<TItem> : IReader<TItem>
    {
        public IWriter<TItem> Writer { get; set; }
        public void read()
        {




        }
        public TItem Read()
        {
            Writer.Display("Donne moi le nom d'un ingredient");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return read
            }

            return new TItem { }
          }
    
    }
}
