using System.ComponentModel.DataAnnotations;

namespace ApiApplication.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string _email { get; set; }

        [Required]
        public string _password { get; set; }
    }

}
