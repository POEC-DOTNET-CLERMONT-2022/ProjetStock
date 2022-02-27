using Microsoft.AspNetCore.Authorization;

namespace ApiApplication.Policy
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string _email { get; set; }
        public  EmailRequirement(string email)
        {
            _email = email;
        }

    }
}
