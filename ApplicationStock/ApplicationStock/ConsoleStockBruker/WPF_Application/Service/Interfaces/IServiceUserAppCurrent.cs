using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.Service.Interfaces
{
    public interface IServiceUserAppCurrent
    {

        Client GetClientCurrent();

        void setClientCurrent(Client client);
        void UpdateClientCurrent(Client client);

        Guid GetGuid();

    }
}
