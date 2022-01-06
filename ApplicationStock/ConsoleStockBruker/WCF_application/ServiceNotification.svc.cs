using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PersistanceStockProjectLibrary;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceNotification" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceNotification.svc ou ServiceNotification.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceNotification : IServiceNotification
    {
        private readonly INotificationManager notifManager;
        public ServiceNotification()
        {
            notifManager = new NotificationManager();
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            return notifManager.GetNotifications();
        }


        public NotificationDto GetById(int id)
        {
            return notifManager.GetById(id);
        }

        public void add(NotificationDto notif)
        {
            notifManager.Add(notif);
        } 
    }
}
