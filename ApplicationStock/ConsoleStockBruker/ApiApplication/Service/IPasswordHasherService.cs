namespace ApiApplication.Service.Interfaces
{
    public interface IPasswordHasherService
    {
         string GetPasswordHasher(string password_not_hashed);
    }
}
