using System;
using System.Collections.Generic;
using System.Text;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary
{
    public interface INotificationManager
    {
        IEnumerable<NotificationDto> GetNotifications();

        NotificationDto GetById(int id);
        IEnumerable<Notification> GetAllNotifications();
        void Update(int id, NotificationDto notificationDto);

        void Add(NotificationDto notificationDto);

        void Delete(NotificationDto notificationDto);
    }
}
