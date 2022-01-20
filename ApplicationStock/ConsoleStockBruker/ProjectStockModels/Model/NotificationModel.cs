using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class NotificationModel : ObservableObject
    {
        public Guid _id;
        public string _textRappel;
        public DateTime _sendAt;


        public Guid Id
        {
            get { return _id; }
            set
            {
                if (value != null)
                {
                    _id = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public string TextRappel
        {
            get { return _textRappel; }
            set
            {
                if (value != null)
                {
                    _textRappel = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public DateTime SendAt
        {
            get { return _sendAt; }
            set
            {
                if (value != null)
                {
                    _sendAt = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
