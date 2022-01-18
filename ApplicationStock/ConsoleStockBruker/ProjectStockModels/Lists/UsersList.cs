using ProjectStockModels.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Lists
{
    public  class UsersList : ObservableObject
    {
        private ObservableCollection<UserModel> _users;

        private UserModel _CurrentUser;

        public UserModel CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                if(_CurrentUser != value)
                {
                    _CurrentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
