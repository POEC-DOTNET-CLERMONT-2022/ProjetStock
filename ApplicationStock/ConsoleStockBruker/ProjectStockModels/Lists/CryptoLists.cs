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
        private ObservableCollection<CryptoModel> _Cryptos;

        private CryptoModel _crypto;


        public CryptoModel currentCrypto
        {
            get { return currentCrypto; }
            set
            {

                if (currentCrypto != value)
                {
                    currentCrypto = value;
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