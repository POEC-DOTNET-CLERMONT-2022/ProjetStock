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
        [DataMember]
        [Required]
        public Guid _id { get; set; }
        [DataMember]
        [Required]
        public  string textRappel { get; set; }
        [DataMember]
        [Required]
        public DateTime sendAt { get; set; }
    }
}
