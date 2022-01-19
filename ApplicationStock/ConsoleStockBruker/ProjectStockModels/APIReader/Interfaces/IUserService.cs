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
        Task<UserModel> Get(UserModel item);

        Task<UserModel> Update(UserModel item);


        Task<int> Delete(UserModel item);
        Task<int> Add(UserModel item);
    }
}
