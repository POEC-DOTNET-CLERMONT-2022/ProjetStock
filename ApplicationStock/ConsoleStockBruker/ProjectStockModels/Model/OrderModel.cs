using ProjectStockLibrary;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class OrderModel : ObservableObject
    {
        public Guid _id;
        public string _orderName;
        public DateTime _orderDate;
        private Stock _stock;
        private int _nbStock;

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != null)
                {
                    _id = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public string OrderName
        {
            get { return _orderName; }
            set
            {
                if (_orderName != null)
                {
                    _orderName = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public Stock Stock
        {
            get { return _stock; }
            set
            {
                if (_stock != null)
                {
                    _stock = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != null)
                {
                    _orderDate = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public int NbStock
        {
            get { return _nbStock; }
            set
            {
                if (_nbStock != null)
                {
                    _nbStock = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
