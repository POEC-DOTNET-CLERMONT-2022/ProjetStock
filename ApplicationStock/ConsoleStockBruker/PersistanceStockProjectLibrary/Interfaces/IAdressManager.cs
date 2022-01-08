using System;
using System.Collections.Generic;
using System.Text;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary.Interfaces
{
    internal interface IAdressManager
    {
        IEnumerable<AddressDto> GetAddress();

        AddressDto GetById(int id);
        IEnumerable <Address> GetAllAddress();
        void Update(int id, AddressDto adressDto);

        void Add(AddressDto adressDto);

        void Delete(AddressDto adressDto);
    }
}
