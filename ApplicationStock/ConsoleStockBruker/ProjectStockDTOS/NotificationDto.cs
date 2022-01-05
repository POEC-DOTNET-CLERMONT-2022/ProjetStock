using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockDTOS

{
    [DataContract]
    internal class NotificationDto
    {
        [DataMember]
        [Required]
        private Guid _id { get; set; }
        [DataMember]
        [Required]
        public  string textRappel { get; set; }
        [DataMember]
        [Required]
        private DateTime sendAt { get; set; }
    }
}
