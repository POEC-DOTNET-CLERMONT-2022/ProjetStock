using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary

{ 

    public static class AdressFactory
    {
        public static IEnumerable<AddressDto> ToDto(this IEnumerable<Address> adresses)
        {
            foreach (var address in adresses)
            {
                yield return address.ToDtoStock();
            }
        }


        public static AddressDto ToDtoStock(this Address adress)
        {
            return new AddressDto() {  Id = adress.Id,_address_line_1=adress._address_line_1,_address_line_2=adress._address_line_2,_city=adress._city,_codePostal=adress._codePostal,_country=adress._country};
        }

        public static IEnumerable<Address> ToDto(this IEnumerable<AddressDto> adresses)
        {
            foreach (var address in adresses)
            {
                yield return address.ToModelStock();
            }
                      
        }

        public static Address ToModelStock(this AddressDto adress)
        {
            return new Address(adress.Id) { _address_line_1 = adress._address_line_1, _address_line_2 = adress._address_line_2, _city = adress._city, _codePostal = adress._codePostal, _country = adress._country };
    }
    }
}