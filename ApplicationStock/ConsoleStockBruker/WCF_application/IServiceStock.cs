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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceStock" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    public interface IServiceStock
    {

        [OperationContract]
        IEnumerable<StockDto> GetStocks();
        [OperationContract]
        StockDto GetById(int id);
        [OperationContract]
        IEnumerable<Stock> GetAllStocks();

        [OperationContract]
        void update(int id, StockDto userDto);

        [OperationContract]
        void add(StockDto userDto);

        [OperationContract]
        void delete(StockDto userDto);

    }
}
