using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectStockLibrary
{
    //public class Reader<TItem> :IReader<TItem>
    //{
    //    public IWriter<TItem> Writer { get; set; }



    //    public void read()
    //    {

    //    }

    //    public TItem create() 
    //    {

    //        Writer.Display("Creer un objet");
    //        TItem item = Activator.CreateInstance<TItem>();
    //        Writer.Display("Quel nom ?");
    //        var name = Console.ReadLine();
    //        if (string.IsNullOrWhiteSpace(name))
    //        {
    //            Writer.Display("Ré-écrire le nom");
    //            this.read();
    //        }
    //        if(item is Stock )
    //        {
    //            Writer.Display("Quel valeur ?");
    //            string valeur  = Console.ReadLine();
    //            if (string.IsNullOrWhiteSpace(valeur))
    //            {
    //                Writer.Display("Ré-écrire la valeur ");
    //                this.read();
    //            }
    //            float valeur_ = float.Parse(valeur);
    //            Writer.Display("Quel entreprise?");
    //            var nameEntreprise = Console.ReadLine();
    //            if (string.IsNullOrWhiteSpace(nameEntreprise))
    //            {
    //                Writer.Display("Ré-écrire le nom de l'entreprise");
    //                this.read();
    //            }
    //        }
    //        if(item is Order)
    //        {
    //            Writer.Display("Quel nbstock ?");
    //            string valeur = Console.ReadLine();
    //            if (string.IsNullOrWhiteSpace(valeur))
    //            {
    //                Writer.Display("Ré-écrire le nbstock ");
    //                this.read();
    //            }
    //            float valeur_ = float.Parse(valeur);
    //            Writer.Display("Quel ordername?");
    //            var nameEntreprise = Console.ReadLine();
    //            if (string.IsNullOrWhiteSpace(nameEntreprise))
    //            {
    //                Writer.Display("Ré-écrire le nom de l'ordernaem");
    //                this.read();
    //            }
    //        }
            

    //        return item;
    //    }
    
    //}
}
