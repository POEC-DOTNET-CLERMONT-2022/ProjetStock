using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockSQLDTOS
{
    [Table("Notification")]
    public class NotificationSqlDtos : IEquatable<NotificationSqlDtos>
    {
        
        [Key]
        public Guid _id { get; private set; }
     
        public string _textRappel { get; set; }
    
        public DateTime sendAt { get; set; }

        public NotificationSqlDtos(string textRappel, DateTime _sendAt)
        {
            _id = Guid.NewGuid();
            _textRappel = textRappel;
            sendAt = _sendAt;
        }
        public bool Equals(NotificationSqlDtos? other)
        {
            if (other == null) return false;
            return true;
        }
    }
}
