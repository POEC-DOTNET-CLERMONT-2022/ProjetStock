using ProjectStockModels.Model;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Lists
{
    public class CryptoLists : ObservableObject
    {
        private ObservableCollection<CryptoModel>? _Cryptos;
        private CryptoModel? _Crypto;


        public CryptoModel Crypto
        {
            get { return _Crypto; }
            set
            {

                if (_Crypto != value)
                {
                    _Crypto = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<CryptoModel> Cryptos
        {
            get { return _Cryptos; }
            set
            {

                if (_Cryptos != value)
                {
                    _Cryptos = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}