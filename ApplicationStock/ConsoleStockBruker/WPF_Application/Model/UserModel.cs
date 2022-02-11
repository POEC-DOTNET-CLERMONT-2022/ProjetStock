using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.Model
{
    internal class UserModel : INotifyPropertyChanged
    {
        private bool isConnected = false;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
