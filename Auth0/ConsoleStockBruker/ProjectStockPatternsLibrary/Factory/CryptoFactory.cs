using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary

{ 

    public static class CryptoFactory
    {
        public static IEnumerable<Crypto> ToDto(this IEnumerable<CryptoDto> cryptos)
        {
            foreach (var crypto in cryptos)
            {
                yield return crypto.ToModel();
            }
                      
        }

        public static Crypto ToModel(this CryptoDto crypto)
        {
            return new Crypto(crypto.Id) { _name = crypto._name, _value = crypto._value };
    }
    }
}