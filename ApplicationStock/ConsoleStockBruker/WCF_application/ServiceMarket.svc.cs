using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PersistanceStockProjectLibrary.Interfaces;
using PersistanceStockProjectLibrary.Manager;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;
namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceMarket" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceMarket.svc ou ServiceMarket.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceMarket : IServiceMarket
    {
       private readonly IMarketManager _marketManager;

        public ServiceMarket()
        {
            _marketManager = new MarketManager();
        }



        public IEnumerable<Market> GetAllMarkets()
        {
            return _marketManager.GetAllMarkets();

        }

        /// <summary>
        /// Gets codex creatures
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarketDto> GetMarkets()
        {
            return _marketManager.GetMarkets();
        }
        public MarketDto GetById(int id)
        {
            return _marketManager.GetById(id);
        }

        public void Update(int id, MarketDto market)
        {
            _marketManager.Update(id, market);
        }

        public void Delete(MarketDto market)
        {
            _marketManager.Delete(market);
        }
        public void Add(MarketDto market)
        {
            _marketManager.Add(market);
        }
    }
}
