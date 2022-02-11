using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public class Notification : BaseEntity
    {
        [Key]
        public  new Guid Id { get; set; }
        public string _textRappel { get; set; }
        public DateTime _sendAt { get;  set; }
        
        public Notification(string textRappel,DateTime sendAt)
        {
            Id = Guid.NewGuid();
            _textRappel = textRappel;
            _sendAt = sendAt;
       
        }

       
    }
}
