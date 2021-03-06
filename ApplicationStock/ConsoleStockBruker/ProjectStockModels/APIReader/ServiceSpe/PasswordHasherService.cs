using ApiApplication.Service;
using ApiApplication.Service.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjectStockModels.APIReader.ServiceSpe
{
    //TODO : à mettre dans une ddl qui sera utilisé que par le serveur 
    internal class PassworsHasherService : IPasswordHasherService
    {
        public string GetPasswordHasher(string password_not_hashed)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password_not_hashed));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                // Print the string.
                // 
                return hash;

            }

        }
    }
}
