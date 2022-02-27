using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApiApplication.Policy
{
    public class IdRequirementHandler : AuthorizationHandler<IdRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdRequirement requirement)
        {
            var user = context.User.FindFirst(
                        c => c.Type == ClaimTypes.Sid);



            if (user is null)
            {
                return Task.CompletedTask;
            }



            if (user.Value.Length > 0)
                context.Succeed(requirement);

            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
