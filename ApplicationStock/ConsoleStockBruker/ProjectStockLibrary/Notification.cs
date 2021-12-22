using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Notification
    {
        private Guid _id { get; set; }
        private string _textRappel { get; set; }
        private DateTime _sendAt { get; set; }
        
        public Notification(string textRappel,DateTime sendAt)
        {
            _id = Guid.NewGuid();
            _textRappel = textRappel;
            _sendAt = sendAt;
        }

 
    }
}
