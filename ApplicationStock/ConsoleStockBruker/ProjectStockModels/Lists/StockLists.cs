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
    public class StockLists : ObservableObject
    {
        private ObservableCollection<StockModel> _Stocks;

        private StockModel _Stock;

        public StockModel Stock
        {
            get { return _Stock; }
            set { 
              if(_Stock != value)
                {
                    _Stock = value;
                    OnNotifyPropertyChanged();
                }
            
            }
        }

        public ObservableCollection<StockModel> Stocks
        {
            get { return _Stocks; }
            set
            {
                if(_Stocks != value) { 
                    _Stocks = value;
                    OnNotifyPropertyChanged();

                }
            }
        }


    }
}
