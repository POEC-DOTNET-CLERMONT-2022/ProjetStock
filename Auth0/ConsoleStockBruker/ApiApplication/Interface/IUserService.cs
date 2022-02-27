using ApiApplication.Models;
using ProjectStockLibrary;

namespace ApiApplication.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Client GetById(Guid id);
    }
}
