using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class AddressModel : ObservableObject
    {
        public Guid _id;
        public string? _address_line_1;
        public string? _address_line_2;
        public string? _codePostal;
        public string? _city;
        public string? _country;
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
        public string Address_line_1
        {
            get { return _address_line_1; }
            set
            {
                if (value != null)
                {
                    _address_line_1 = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public string Address_line_2
        {
            get { return _address_line_2; }
            set
            {
                //TODO : condition inutile
                if (value != null)
                {
                    _address_line_2 = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public string CodePostal
        {
            get { return _codePostal; }
            set
            {
                if (value != null)
                {
                    _codePostal = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                //TODO : condition inutile
                if (value != null)
                {
                    _city = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public string Country
        {
            get { return _country; }
            set
            {
                if (value != null)
                {
                    _country = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
      

    }
}
