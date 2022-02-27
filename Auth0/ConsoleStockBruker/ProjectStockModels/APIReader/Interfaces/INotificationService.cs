using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationModel>> GetAll();

        Task<NotificationModel> Get(Guid id);
        Task<int> Update(NotificationModel item);


        Task<int> Delete(Guid id);
        Task<int> Add(NotificationModel item);
    }
}
