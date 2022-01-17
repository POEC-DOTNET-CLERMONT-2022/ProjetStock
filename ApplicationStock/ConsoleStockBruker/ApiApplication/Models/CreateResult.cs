using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ApiApplication.Models
{
    public class CreateResult
    {
        [DataMember]
        [Required]
        public string _firstName { get;  set; }
        [DataMember]
        [Required]
        public string _lastName { get; set; }
        [DataMember]
        [Required]
        public string _email { get; set; }
        [DataMember]
        [Required]
        public string _password { get; set; }
    }
}
