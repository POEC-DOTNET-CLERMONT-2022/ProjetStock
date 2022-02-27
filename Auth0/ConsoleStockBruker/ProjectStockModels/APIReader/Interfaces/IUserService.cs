using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll();

        Task<UserModel> Get(Guid id);
        Task<int> Update(UserModel item);


        Task<int> Delete(Guid id);
        Task<int> Add(UserModel item);
    }
}
