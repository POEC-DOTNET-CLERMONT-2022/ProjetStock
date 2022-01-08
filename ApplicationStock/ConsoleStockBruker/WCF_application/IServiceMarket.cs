using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceMarket" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceMarket
    {
        [OperationContract]
         IEnumerable<MarketDto> GetMarkets();
        [OperationContract]
        IEnumerable<Market> GetAllMarkets();

        [OperationContract]
        MarketDto GetById(int id);

        [OperationContract]
        void Update(int id, MarketDto marketDto);

        [OperationContract]
        void Add(MarketDto marketDto);

        [OperationContract]
        void Delete(MarketDto marketDto);
        

    }
}
