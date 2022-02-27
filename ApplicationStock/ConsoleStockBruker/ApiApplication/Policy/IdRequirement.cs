using Microsoft.AspNetCore.Authorization;

namespace ApiApplication.Policy
{
    public class IdRequirement :IAuthorizationRequirement
    {
        public Guid Id { get; set; }

        public IdRequirement(Guid id)
        {
            Id = id;
        }
    }
}
