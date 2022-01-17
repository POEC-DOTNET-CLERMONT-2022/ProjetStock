using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ApiApplication.Models
{
    public class GetClass
    {
        [DataMember]
        [Required]
        public Guid _id { get; set; }
    }
}
