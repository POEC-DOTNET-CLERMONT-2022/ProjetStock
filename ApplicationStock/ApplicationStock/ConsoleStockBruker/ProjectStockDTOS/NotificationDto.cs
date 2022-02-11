using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockDTOS
{
    public  class NotificationDto
    {
        public Guid Id { get; set; }
        public  string? textRappel { get; set; }
        public DateTime sendAt { get; set; }
    }
}
