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
        public Guid _id;
        public string _name;
        public float _value;
        public string _entrepriseName;

       
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



        public float Value
        {
            get { return _value; }
            set
            {
                if (value != null)
                {
                    _value = value;
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



        public string EntrepriseName
        {
            get { return _entrepriseName; }
            set
            {
                if (value != null)
                {
                    _entrepriseName = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


       

    }
}
