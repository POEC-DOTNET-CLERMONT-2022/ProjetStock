using MyStockModels;
using ProjectStockLibrary;


Console.WriteLine("Hello, World!");

Manager<Market> marketManager = new Manager<Market>(new Writer<Market>(), new Reader<Market>());



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
