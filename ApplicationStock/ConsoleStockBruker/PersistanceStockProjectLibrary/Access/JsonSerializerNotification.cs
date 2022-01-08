using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersistanceStockProjectLibrary.Interfaces;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary
{
    public class JsonSerializerNotification : IPersistanceJsonNotification
    {
        private readonly List<Notification> _notifs;

        public List<Notification> GetNotificationsJson(string[] _strings)
        {
            foreach(var _string in _strings)
            {
                Notification _notif = this.readJsonNotif(_string);
                if (!_notifs.Contains(_notif) && _notif != null)
                {
                    _notifs.Add(_notif);
                }
            }

            return _notifs;
        }

        public Notification readJsonNotif(string jsonString)
        {
           
            JObject o = JObject.Parse(jsonString);
            string text = (o["notification"].ToString().Contains("textRappel")).ToString();
            string datetime = (o["notification"].ToString().Contains("dateRappel")).ToString();
            DateTime date = DateTime.Parse(datetime);
            if (!text.Equals(null) && !date.Equals(null))
            {

                Notification _notif = new Notification(text, date);
                return _notif;
            }
            return null;
           
        }
        
        public string writeJsonNotifs(List<Notification> _notifs)
        {
            string jsonString = "";
            foreach(var _notif in _notifs)
            {
                jsonString += JsonConvert.SerializeObject(_notif);

            }
            return jsonString;

          
        }

        public string writeJsonNotif(Notification notif)
        {
            return JsonConvert.SerializeObject(notif);
        }
    }
}
