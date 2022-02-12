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
        public string? _orderName;
        public DateTime _orderDate;
        public Stock _stock;
        public int _nbStock;
        public Guid _clientId;

        public Guid ClientId
        {
            get { return _id; }
            set
            {
                if (value != null)
                {
                    _id = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (value != null)
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
                if (value != null)
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
                if (value != null)
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
                if (value != null)
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
                if (value != null)
                {
                    _nbStock = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
