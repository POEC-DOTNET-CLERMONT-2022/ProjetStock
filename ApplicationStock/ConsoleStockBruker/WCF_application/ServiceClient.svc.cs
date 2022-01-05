using PersistanceStockProjectLibrary;
using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_application
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClient" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClient.svc ou ServiceClient.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClient : IServiceClient
    {
        private readonly IUserManager userManager;
        public ServiceClient()
        {

            userManager = new UserManager();
        }
    
        public IEnumerable<UserDto> GetAllUsers()
        {
            return userManager.GetAllUsers();
        }

        [OperationContract]
        public IEnumerable<Client> GetUsers()
        {
            return userManager.GetUsers();
        }

        [OperationContract]
        public UserDto GetUser(int id)
        {
            return userManager.GetUser(id);
        }

        [OperationContract]
        public void update(int id, UserDto userDto)
        {
            userManager.Update(id, userDto);
        }

        [OperationContract]
        public void add(UserDto userDto)
        {
            userManager.Add(userDto);
        }

        [OperationContract]
        public void delete(UserDto userDto)
        {
            userManager.Delete(userDto);
        }
    }
}
