using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Notification
    {
        public Guid _id { get; set; }
        public string _textRappel { get; private set; }
        public DateTime _sendAt { get; private set; }
        
        public Notification(string textRappel,DateTime sendAt)
        {
            _id = Guid.NewGuid();
            _textRappel = textRappel;
            _sendAt = sendAt;
        }

 
    }
}
