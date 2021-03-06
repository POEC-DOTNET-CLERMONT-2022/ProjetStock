using ProjectStockLibrary;
using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class UserModel : ObservableObject
    {
        public Guid _id;
        public string _lastName;
        public string _firstName;
        public string _email;

       
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
       

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null)
                {
                    _firstName = value;
                    OnNotifyPropertyChanged();
                }
                    
            }
        }
       

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != null)
                {
                    _lastName = value;
                    OnNotifyPropertyChanged();
                }

            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value != null)
                {
                    _email = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        public string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value != null)
                {
                    _phone = value;
                    OnNotifyPropertyChanged();
                }
                

            }
        }
        public string _siret;


        public string Siret
        {
            get { return _siret; }
            set
            {
                if (value != null)
                {
                    _siret = value;
                    OnNotifyPropertyChanged();
                }

            }
        }
        public List<Order> _orders;


        public List<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (value != null)
                {
                    _orders = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        public List<Notification> _notifs;

        public List<Notification> Notifications
        {
            get { return _notifs; }
             set   {
                if (value != null)
                {
                        _notifs = value;
                    OnNotifyPropertyChanged();
                }

            }
        }



        public List<Address> _addresses;


        public List<Address> Addresses
        {
            get { return _addresses; }
            set
            {
                if (value != null)
                {
                    _addresses  = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        public  List<Stock> _stocks;

        public List<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                if (value != null)
                {
                    _stocks = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        public string _token;

        public string Token
        {
            get { return _token; }
            set
            {
                if (value != null)
                {
                    _token = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        public string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnNotifyPropertyChanged();
                }

            }
        }

        public DateTime _expireToken;

        public DateTime ExpireToken
        {
            get { return _expireToken; }
            set
            {
                if (value != null)
                {
                    _expireToken = value;
                    OnNotifyPropertyChanged();
                }

            }
        }

    }
}
