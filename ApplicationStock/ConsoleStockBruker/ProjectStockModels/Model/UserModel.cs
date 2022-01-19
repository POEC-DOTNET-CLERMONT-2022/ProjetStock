using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels
{
    public class UserModel : INotifyPropertyChanged
    {
        private Guid _id;

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
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != null)
                {
                    _firstName = value;
                    OnNotifyPropertyChanged();
                }
                    
            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != null)
                {
                    _lastName = value;
                    OnNotifyPropertyChanged();
                }

            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != null)
                {
                    _email = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone!= null)
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
                if (_siret!= null)
                {
                    _siret = value;
                    OnNotifyPropertyChanged();
                }

            }
        }


    }
}
