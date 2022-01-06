using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary
{
    public static class UserFactory
    {
        public static IEnumerable<UserDto> ToDto(this IEnumerable<Client> users)
        {
            foreach (var user in users)
            {
                yield return user.ToDto();
            }
        }


        public static UserDto ToDto(this Client user)
        {
            return new UserDto() { _firstName = user._firstName, _lastName = user._lastName, _email = user._email, _phone = user._phone, _siret = user._siret };
        }


        public static IEnumerable<Client> ToModel(this IEnumerable<UserDto> users)
        {
            foreach (var user in users)
            {
                yield return user.ToModel();
            }
        }


        public static Client ToModel(this UserDto user)
        {
            return new Client() { _siret = user._siret, _firstName = user._firstName, _lastName = user._lastName , _email = user._email , _phone = user._phone };
        }

    }
}