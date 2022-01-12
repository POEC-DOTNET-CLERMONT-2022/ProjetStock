using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface INotificationRepository
    {
        NotificationEntity? Add(NotificationEntity notifEntity);

        NotificationEntity? Update(NotificationEntity notifEntity);


        bool Delete(Guid id);


        NotificationEntity? GetSingle(Guid id);

    }
}
