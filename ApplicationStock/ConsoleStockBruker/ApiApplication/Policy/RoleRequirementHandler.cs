using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ApiApplication.Policy
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var user_roles = context.User.FindFirst(
                        c => c.Type == ClaimTypes.Role);



            if (user_roles is null)
            {
                return Task.CompletedTask;
            }



            if (user_roles.Value == "user:Admin")
                context.Succeed(requirement);
            if (user_roles.Value == "user:User")
                context.Succeed(requirement);

            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
