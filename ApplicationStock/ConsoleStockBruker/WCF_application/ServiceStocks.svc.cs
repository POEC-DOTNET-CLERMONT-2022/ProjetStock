using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_application.Dtos;
using WCF_application.Manager;

namespace WCF_application.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceStock : IServiceStock
    {
        private readonly StockManager stockManager;

        /// <summary>
        /// Initialize a new ServiceStock
        /// </summary>
        public ServiceStock()
        {
            stockManager = new StockManager();
        }

        /// <summary>
        /// Gets codex creatures
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetStocks()
        {
            return stockManager.GetStocks();
        }
    }

}
