using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Interfaces
{
    internal interface IAddressService
    {
        Task<IEnumerable<AddressModel>> GetAll();

        Task<AddressModel> Get(Guid id);

        Task<int> Update(AddressModel item);

        Task<int> Delete(Guid id);

        Task<int> Add(AddressModel item);
    }
}
