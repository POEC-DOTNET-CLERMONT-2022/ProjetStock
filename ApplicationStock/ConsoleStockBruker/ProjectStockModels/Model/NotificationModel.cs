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
        private Guid _id;
        private string _textRappel;
        private DateTime _sendAt { get; set; }


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
