using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectStockLibrary;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiApplication.Helpers;

namespace ApiApplication
{
    public class UserService : IUserService
    {
        private APIContext _context;

        private readonly AppSetting _appSettings;

        public UserService(APIContext context)
        {
            _appSettings = new AppSetting();
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context._users.SingleOrDefault(x => x._email == model._email && x._password == model._password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            user.setToken(token);
            user.setExpireDate(DateTime.UtcNow.AddDays(7));
            _context._users.Update(user);
            _context.SaveChanges();

            return new AuthenticateResponse(user, token);
        }
        public Client GetById(Guid id)
        {
            return _context._users.FirstOrDefault(x => x._id == id);
        }

        // helper methods

        private string generateJwtToken(Client user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user._id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret phase ez^pozâoeaz^pozapeozaêoazeoazeoazpeoaézeopeozapoaézpepôaezpeoaô")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var send_token = tokenHandler.WriteToken(token);
            

            return send_token;
        }
    }
}
