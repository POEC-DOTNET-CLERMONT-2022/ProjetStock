using ProjectStockLibrary;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class CryptoModel : ObservableObject
    {
        private Guid _id;
        private string? _name;
        private float _value;
        private List<Client>? _clients;
        private List<Market>? _markets;

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
        public string Name
        {
            get { return _name; }
            set
            {
                if(value != null)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                } 
            }
        }
        public float Value
        {
            get { return _value; }
            set
            {
                //TODO : condition inutile
                if (value != null )
                {
                    _value = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public List<Client> Clients
        {
            get { return _clients; }
            set
            {
                if(value != null)
                {
                    _clients = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public List <Market> Markets
        {
            get { return _markets; }
            set
            {
                if(value != null)
                {
                    _markets = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
