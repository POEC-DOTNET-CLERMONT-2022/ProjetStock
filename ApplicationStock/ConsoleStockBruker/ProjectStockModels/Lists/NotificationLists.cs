using ProjectStockModels.Model;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Lists
{
    public class NotificationLists : ObservableObject
    {
        //TODO : nommage
        private ObservableCollection<NotificationModel>? _Notifs;
        private NotificationModel? _Notif;

        public  NotificationModel Notif
        {
            get { return _Notif; }
            set {
                
              if(value != _Notif)
                {
                    _Notif = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<NotificationModel> Notifs
        {
            get { return _Notifs; }
            set {

                if (value != _Notifs)
                {
                    _Notifs = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
