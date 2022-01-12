using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Interfaces
{
    internal interface IAddressRepository
    {
        AddressEntity? Add(AddressEntity addressEntity);

        AddressEntity? Update(AddressEntity adressEntity);


        bool Delete(Guid id);


        AddressEntity? GetSingle(Guid id);
    }
}
