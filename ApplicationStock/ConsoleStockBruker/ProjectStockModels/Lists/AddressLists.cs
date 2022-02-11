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
    public class AddressLists : ObservableObject
    {
        private ObservableCollection<AddressModel>? _Addresses;
        private AddressModel? _Address;
        public AddressModel Address
        {
            get { return _Address; }
            set
            {

                if (_Address != value)
                {
                    _Address = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<AddressModel> Addresses
        {
            get { return _Addresses; }
            set
            {

                if (_Addresses != value)
                {
                    _Addresses = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
