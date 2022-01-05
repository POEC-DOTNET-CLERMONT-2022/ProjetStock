using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;
using ProjectStockLibrary;

namespace ConsoleStockBruker
{
    internal class ConsoleReaderCommande : IReaderCommande
    {
        public IWriterCommande Writer { get; set; }


        public Order create(Stock stock)
        {
            Writer.Display("Donne moi le nom de l'action");
            var Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create(stock);
            }
            Writer.Display("Donne moi le nom de l'action");
            var nbStock = int.Parse(Console.ReadLine());

            if (string.IsNullOrWhiteSpace(Name))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create(stock);
            }

            return new Order(Name,stock,nbStock);
        }

        public Order update(Order order, Stock stock)
        {
            Writer.Display("Modification de l'order " + order._orderName);
            Writer.Display("Donne moi le nom de la commande ");
        
            Writer.Display("Donne moi le nom de l'action");
            var nbStock = int.Parse(Console.ReadLine());

            if (nbStock == null || nbStock < 0)
            {
                Writer.Display("Mauvais chiffre!");
                return update(order, stock);
            }


            order.modifyOrder(order, stock, nbStock);

            return order;
        }
    }
}
