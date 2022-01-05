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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceClient" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceClient
    {
        [OperationContract]
        IEnumerable<UserDto> GetAllUsers();

        [OperationContract]
        IEnumerable<Client> GetUsers();

        [OperationContract]
        UserDto GetUser(int id);

        [OperationContract]
        void update(int id, UserDto userDto);

        [OperationContract]
        void add(UserDto userDto);

        [OperationContract]
        void delete(UserDto userDto);

    }
}
