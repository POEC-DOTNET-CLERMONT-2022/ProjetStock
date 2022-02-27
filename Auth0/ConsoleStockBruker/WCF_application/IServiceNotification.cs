using ProjectStockDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceNotification" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceNotification
    {
        [OperationContract]
        IEnumerable<NotificationDto> GetNotifications();
        [OperationContract]
        NotificationDto GetById(int id);

        [OperationContract]
        void add(NotificationDto userDto);
    }
}
