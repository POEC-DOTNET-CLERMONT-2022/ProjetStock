using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersistanceStockProjectLibrary.Interfaces;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary.Access
{
    internal class JsonSerializerUser : IPersistanceJsonUser
    {
        private readonly List<Client> _users;


        public List<Client> GetClientsJson(string[] _strings)
        {
            foreach (var _string in _strings)
            {
                Client _user = this.readJsonClient(_string);
                if (!_users.Contains(_user) && _user != null)
                {
                    _users.Add(_user);
                }
            }
            return _users;

        }
        public Client readJsonClient(string jsonString)
        {
            JObject o = JObject.Parse(jsonString);
            string firstName = (o["client"].ToString().Contains("firstName")).ToString();
            string lastName= (o["client"].ToString().Contains("lastName")).ToString();
            string email = (o["client"].ToString().Contains("email")).ToString();
            string phone = (o["client"].ToString().Contains("phone")).ToString();
            string siret = (o["client"].ToString().Contains("siret")).ToString();

                Client client = new Client(firstName,lastName, email,phone,siret);
                return client;
        }

        public  string writeJsonClients(List<Client> users)
        {
            string jsonString = "";
            foreach (var _user in users)
            {
                jsonString += JsonConvert.SerializeObject(_user);

            }
            return jsonString;

        }

        public string writeJsonClient(Client user)
        {
            return JsonConvert.SerializeObject(user);
        }
    }
}
