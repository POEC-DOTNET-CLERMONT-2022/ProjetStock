﻿using ProjectStockLibrary;
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
        public string _firstName;

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
        public string _email;

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


    }
}
