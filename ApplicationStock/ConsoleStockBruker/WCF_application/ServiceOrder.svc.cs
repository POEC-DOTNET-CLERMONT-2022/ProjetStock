using PersistanceStockProjectLibrary.Interfaces;
using PersistanceStockProjectLibrary.Manager;
using ProjectStockDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceOrder" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceOrder.svc ou ServiceOrder.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceOrder : IServiceOrder
    {
        private readonly IOrderManager orderManager;

        public ServiceOrder()
        {
            orderManager = new OrderManager();
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            return orderManager.GetOrders();
        }
        
         public OrderDto GetById(int id)
        {
            return orderManager.GetById(id);
        }

   
        public void add(OrderDto OrderDto)
        {
            orderManager.add(OrderDto);
        }

        public void delete(OrderDto OrderDto)
        {
            orderManager.delete(OrderDto);
        }
    }
}
