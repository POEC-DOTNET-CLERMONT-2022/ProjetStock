using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectStockLibrary;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
namespace ApiApplication.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private APIContext _context;

        public AuthorizeAttribute()
        {
            _context = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var p = _context._users.Where(x => x._token == token);

            Client client = null;
            foreach(var user in p)
            {
                 client = user;
            }

            if (client == null || client._expireToken < DateTime.Now)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
          
        }
    }
}
