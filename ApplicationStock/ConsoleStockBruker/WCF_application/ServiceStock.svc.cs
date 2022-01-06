
using PersistanceStockProjectLibrary;
using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProjectStockPatternsLibrary;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceStock" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceStock.svc ou ServiceStock.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceStock : IServiceStock
    {
        private readonly IStockManager stockManager;

        /// <summary>
        /// Initialize a new ServiceStock
        /// </summary>
        public ServiceStock()
        {
            stockManager = new StockManager();
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return stockManager.GetAllStocks();
        }

        /// <summary>
        /// Gets codex creatures
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockDto> GetStocks()
        {
            return stockManager.GetStocks();
        }
        public StockDto GetById(int id)
        {
            return stockManager.GetById(id);
        }

        public void update(int id, StockDto stock)
        {
            stockManager.Update(id, stock);
        }

        public void delete(StockDto stock)
        {
            stockManager.Delete(stock);
        }
        public void add(StockDto stock)
        {
            stockManager.Add(stock);
        }
    }
}
