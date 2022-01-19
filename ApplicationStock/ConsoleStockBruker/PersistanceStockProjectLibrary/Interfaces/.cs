using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceStockProjectLibrary.Interfaces
{
    internal interface IPersistanceJsonUser
    {
        List<Client> GetClientsJson(string[] _strings);
        Client readJsonClient(string jsonString);

        string writeJsonClient(Client user);

        string writeJsonClients(List<Client> _users);
    }
}
