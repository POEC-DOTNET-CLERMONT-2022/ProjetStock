using ProjectStockLibrary;

namespace ApiApplication.Models
{
    public class AuthenticateResponse
    {

 
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _email { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }

        public AuthenticateResponse(Client user, string token)
        {
            _firstName = user._firstName;
            _lastName = user._lastName;
            _email = user._email;
            Token = token;
            Id = user.Id;
        }
    }
}
