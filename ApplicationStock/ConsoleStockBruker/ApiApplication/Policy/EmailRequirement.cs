using Microsoft.AspNetCore.Authorization;

namespace ApiApplication.Policy
{
    public class EmailRequirementPolicy : IAuthorizationRequirement
    {
        public string _email { get; set; }
        public  EmailRequirementPolicy(string email)
        {
            _email = email;
        }

    }
}
