using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Application.Service.Interfaces;

namespace WPF_Application.Service.Services
{
    internal class ServiceClientCurrent: IServiceUserAppCurrent
    {


        private Client currentClientApp;
     

        public ServiceClientCurrent(Client currentClient)
        {
            currentClientApp = currentClient;

        }

        public ServiceClientCurrent()
        {
            currentClientApp = new Client();
        }


        public Client GetClientCurrent()
        {
            return this.currentClientApp;

        }


        public  void UpdateClientCurrent(Client client)
        {
          
                currentClientApp = client;
            
        }



        public void setClientCurrent(Client client)
        {
            if (currentClientApp != null)
                currentClientApp = client;
            else
                currentClientApp = null;
        }



        public Guid GetGuid()
        {
            if (currentClientApp != null)
                return this.currentClientApp._id;

            return Guid.Empty;
        }

      
    }
}
