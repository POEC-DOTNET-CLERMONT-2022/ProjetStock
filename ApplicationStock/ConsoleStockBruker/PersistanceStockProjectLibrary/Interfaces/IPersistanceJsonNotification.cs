using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceStockProjectLibrary.Interfaces
{
    public interface IPersistanceJsonNotification 
    {
        List<Notification> GetNotificationsJson(string[] _strings);
        Notification readJsonNotif(string jsonString);

        string  writeJsonNotif(Notification notif);

        string writeJsonNotifs(List<Notification> _notifs);

    }
}
