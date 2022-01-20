﻿using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Model
{
    public class MarketModel : ObservableObject
    {
        private Guid _id { get; set; }
        private string _name { get; set; }
        private DateTime _openingDate { get; set; }
        private DateTime _closingDate { get; set; }
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
                if (value != null)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                }

            }
        }

        public DateTime OpeningDate
        {
            get { return _openingDate; }
            set
            {
                if (_openingDate != null)
                {
                    _openingDate = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public DateTime ClosingDate
        {
            get { return _closingDate; }
            set
            {
                if (value != null)
                {
                    _closingDate = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
