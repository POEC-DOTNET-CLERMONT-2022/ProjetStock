using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Security.Claims;

namespace ApiApplication.Policy
{
    public class EmailRequirementHandler : AuthorizationHandler<EmailRequirement>
    {
       

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            var email = context.User.FindFirst(
             c => c.Type==  ClaimTypes.Email);



            if (email is null)
            {
                return Task.CompletedTask;
            }

            MailAddress m = new MailAddress(email.Value);

            if (m.User.Length > 0)
                context.Succeed(requirement);

            else
                context.Fail();

            return Task.CompletedTask;
            
        }
    }
}
