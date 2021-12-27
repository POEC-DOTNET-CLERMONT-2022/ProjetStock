using MyStockModels;
using ProjectStockLibrary;


Console.WriteLine("Hello, World!");

ManagerMarket marketManager = new ManagerMarket(new IwriterMarket(), new Reader<Stock>());



while (true)
{
    Console.WriteLine("1: read, 2: create");
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            marketManager.read();
            break;
        case 2:
            marketManager.Create();
            break;
        default:
            Console.WriteLine("Fin du programme");

            Environment.Exit(0);
            break;
    }

}




Console.ReadLine();
