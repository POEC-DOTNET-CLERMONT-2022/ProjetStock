using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockEntity
{
    [Table("Notification")]
    public sealed class NotificationEntity : IEquatable<NotificationEntity>
    {
        
        [Key]
        public Guid _id { get; private set; }
     
        public string _textRappel { get; set; }
    
        public DateTime sendAt { get; set; }

        //public NotificationEntity(string textRappel, DateTime _sendAt)
        //{
        //    _id = Guid.NewGuid();
        //    _textRappel = textRappel;
        //    sendAt = _sendAt;
        //}
        public bool Equals(NotificationEntity? other)
        {
            if (other == null) return false;
            return true;
        }
    }
}
