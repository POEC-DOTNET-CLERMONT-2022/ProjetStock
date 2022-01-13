using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyStockModels;
using ProjectStockLibrary;

namespace ConsoleStockBruker
{
    internal class ConsoleReaderClient : IReaderClient
    {
        public IWriterClient Writer { get; set; }

        public Client create()
        {
            Writer.Display("Donne moi le prenom du client");
            var firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }
            Writer.Display("Donne moi le nom du client");
            var lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }

            Writer.Display("Donne moi le email du client");
            var email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (string.IsNullOrWhiteSpace(email) && match.Success)
            {
                Writer.Display("Ce email n'est pas bon !");
                return create();
            }
            Writer.Display("Donne moi votre bigot");
            var phone = Console.ReadLine();
            Regex regex_phone = new Regex(@"/ ^(33 | 0)(6 | 7 | 9)\d{ 8}$/");
            Match match_phone = regex.Match(phone);
        
            if (string.IsNullOrWhiteSpace(phone) && match_phone.Success)
            {
                Writer.Display("Ce nom n'est pas bon !");
                return create();
            }
            Writer.Display("Donne moi le siret");
            var siret = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(siret))
            {
                Writer.Display("Mauvais siret !");
                return create();
            }


            return new Client(firstName,lastName, email, phone, siret);
        }

        public Client update(Client client)
        {
            Writer.Display("Donne moi le prenom du client");
            var firstName = Console.ReadLine();

            if (string.IsNullOrEmpty(firstName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return update(client);
            }
            Writer.Display("Donne moi le nom du client");
            var lastName = Console.ReadLine();

            if (string.IsNullOrEmpty(lastName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return update(client);
            }

            Writer.Display("Donne moi le email du client");
            var email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!string.IsNullOrWhiteSpace(email) && !match.Success)
            {
                Writer.Display("Ce email n'est pas bon !");
                return update(client);
            }
            Writer.Display("Donne moi votre bigot");
            var phone = Console.ReadLine();
            Regex regex_phone = new Regex(@"/ ^(33 | 0)(6 | 7 | 9)\d{ 8}$/");
            Match match_phone = regex_phone.Match(phone);

            if (!string.IsNullOrWhiteSpace(phone) && match_phone.Success)
            {
                Writer.Display("Ce nom n'est pas bon !");
                return update(client);
            }
            Writer.Display("Donne moi le siret");
            var siret = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(siret))
            {
                Writer.Display("Mauvais siret !");
                return update(client);
            }
           

            return client;
        }
    }
}
