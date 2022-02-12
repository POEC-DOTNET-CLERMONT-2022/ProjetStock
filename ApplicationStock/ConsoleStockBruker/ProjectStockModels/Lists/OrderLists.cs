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
    public class OrderLists : ObservableObject
    {
        private ObservableCollection<OrderModel>? _Orders;
        private OrderModel? _Order;

        public OrderModel Order
        {
            get { return _Order; }
            set { 
                 if(_Order != value)
                {
                    _Order = value;
                    OnNotifyPropertyChanged();
                }
                
              }
        }

   
        public ObservableCollection<OrderModel> Orders
        {
            get { return  _Orders; }
            set { 
               if(_Orders != null)
                {
                    _Orders = value;
                    OnNotifyPropertyChanged();
                }

                  
            }
        }

    }
}
