
using ConsoleStockBruker;
using MyStockModels;

Console.WriteLine("Application Stock  - Version console ");

var marketManager = new MarketManager(new ConsoleWriterMarket(), new ConsoleReaderMarket());
bool monBool = true;
while (monBool)
{
    Console.WriteLine("Market");
    Console.WriteLine("1: read a market , 2: create a market ,3 - delete market , 4 - update market");
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            marketManager.read();
            break;
        case 2:
            marketManager.Create();
            break;
        case 3:
            marketManager.readAll();
            Console.WriteLine("\nChoix a supprimer");
            int choix = int.Parse(Console.ReadLine());
            marketManager.delete(choix);
            break;
        case 4:
            marketManager.readAll();
            Console.WriteLine("\nChoix a modifier");
            int choix_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Update");
            marketManager.update(choix_update);

            break;
        default:
            Console.WriteLine("Fin Market");

            monBool = false;
            break;
    }

}
var clientManager = new ClientManager(new ConsoleWriterClient(), new ConsoleReaderClient());
bool _monBool = true;
while (_monBool)
{
    Console.WriteLine("Client");
    Console.WriteLine("1: read a client , 2: create a client ,3 - delete client , 4 - update client");
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            clientManager.read();
            break;
        case 2:
            clientManager.Create();
            break;
        case 3:
            clientManager.readAll();
            Console.WriteLine("\nChoix a supprimer");
            int choix = int.Parse(Console.ReadLine());
            clientManager.delete(choix);
            break;
        case 4:
            clientManager.readAll();
            Console.WriteLine("\nChoix a modifier");
            int choix_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Update");
            clientManager.update(choix_update);

            break;
        default:
            Console.WriteLine("Fin Client");

            _monBool = false;
            break;
    }

}

bool iscontinue = true;

StockManager stockmanager = new StockManager(new ConsoleWriterStocks(),new ConsoleReaderStock());

while (iscontinue)
{
    Console.WriteLine("Stock");
    Console.WriteLine("1: read a Stock , 2: create a Stock ,3 - delete Stock , 4 - update stock");
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            stockmanager.read();
            break;
        case 2:
            stockmanager.Create();
            break;
        case 3:
            Console.WriteLine("erreur");
            stockmanager.readAll();
            Console.WriteLine("\nChoix a supprimer");
            int choix = int.Parse(Console.ReadLine());
            stockmanager.delete(choix);
            break;
        case 4:
            stockmanager.readAll();
            Console.WriteLine("\nChoix a modifier");
            int choix_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Update");
            stockmanager.update(choix_update);
            break;
        default:
            Console.WriteLine("Fin partie stock");

            iscontinue = false;
            break;
    }

}


var commandeManager = new CommandeManager(new ConsoleWriterCommande(), new ConsoleReaderCommande());

while (true)
{
    Console.WriteLine("Stock");
    Console.WriteLine("1: read a Commande , 2: create a commande,3 - delete commande , 4 - update market");
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            commandeManager.read();
            break;
        case 2:
            commandeManager.Create(new ConsoleReaderStock().create());
            break;
        case 3:
            commandeManager.readAll();
            Console.WriteLine("\nChoix a supprimer");
            int choix = int.Parse(Console.ReadLine());
            commandeManager.delete(choix);
            break;
        case 4:
            commandeManager.readAll();
            Console.WriteLine("\nChoix a modifier");
            int choix_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Update");
            commandeManager.update(choix_update);
            break;
        default:
            Console.WriteLine("Fin partie commande");

            Environment.Exit(0);
            break;
    }

}




Console.ReadLine();
