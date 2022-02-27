using Microsoft.AspNetCore.Authorization;

namespace ApiApplication.Policy
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string[] roles { get; set; }

        public RoleRequirement(string[] myroles)
        {
            this.roles = myroles;
        }

    }
}
