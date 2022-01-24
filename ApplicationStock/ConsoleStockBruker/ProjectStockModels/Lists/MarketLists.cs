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
    public class MarketLists : ObservableObject
    {
        private ObservableCollection<MarketModel>? _Markets;

        private MarketModel? _market;

        
        public MarketModel currentMarket
        {
            get { return _market; }
            set { 

                if (_market != value)
                {
                    currentMarket = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<MarketModel> Markets
        {
            get { return _Markets; }
            set{

                if (_Markets != value)
                {
                    _Markets = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
