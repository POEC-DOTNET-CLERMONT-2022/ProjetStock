using ProjectStockLibrary;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class StockModel : ObservableObject
    {
        private Guid _id;
        public string _name;
        public float _value;
        public string _entrepriseName;

        private List<Client> _clients;

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
        public float Value
        {
            get { return _value; }
            set
            {
                if (_value != null)
                {
                    _value = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public List<Client> Client
        {
            get { return _clients; }
            set
            {
                if (_clients != null)
                {
                    _clients = value;
                    OnNotifyPropertyChanged();
                }
            }
        }



        public string EntrepriseName
        {
            get { return _entrepriseName; }
            set
            {
                if (_entrepriseName != null)
                {
                    _entrepriseName = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


       

    }
}
