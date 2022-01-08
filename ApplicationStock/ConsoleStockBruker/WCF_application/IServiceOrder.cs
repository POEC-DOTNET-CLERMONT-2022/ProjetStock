using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceOrder" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceOrder
    {
            [OperationContract]
            IEnumerable<OrderDto> GetOrders();
            [OperationContract]
            OrderDto GetById(int id);

            [OperationContract]
            void add(OrderDto userDto);

            [OperationContract]
            void delete(OrderDto userDto);
       
    }
}
