
using ConsoleStockBruker;
using MyStockModels;

Console.WriteLine("Application Stock  - Version console ");

var marketManager = new MarketManager(new ConsoleWriterMarket(), new ConsoleReaderMarket());
bool monBool = true;
while (monBool)
{
    Console.WriteLine("Market");
    Console.WriteLine("1: read a market , 2: create a market ,3 - update market");
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
            
            break;
        default:
            Console.WriteLine("Fin Market");

            monBool = false;
            break;
    }

}

bool iscontinue = true;

StockManager stockmanager = new StockManager(new ConsoleWriterStocks(),new ConsoleReaderStock());

while (iscontinue)
{
    Console.WriteLine("Stock");
    Console.WriteLine("1: read a Stock , 2: create a Stock ,3 - update Stock");
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
            stockmanager.update(Stock);
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
    Console.WriteLine("1: read a Commande , 2: create a commande,3 - update commande");
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
            Console.WriteLine("erreur");
            commandeManager.update();
            break;
        default:
            Console.WriteLine("Fin partie commande");

            Environment.Exit(0);
            break;
    }

}




Console.ReadLine();
