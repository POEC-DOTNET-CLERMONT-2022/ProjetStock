using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Application.State
{
    /// <summary>
    /// Logique d'interaction pour ProjectVisualState.xaml
    /// </summary>
    public partial class ProjectVisualState : Window, INotifyPropertyChanged
    {
        public ProjectVisualState()
        {
            InitializeComponent();
            DataContext = this;
        }
        private RecState _recState;

        public RecState RecState
        {
            get { return _recState; }
            set
            {
                if (_recState != value)
                {
                    _recState = value;
                    OnPropertyChanged();
                }
            }
        }

     

        /// <summary>
        /// Méthode qui change l'état de notre élément 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGoToSmall(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Small;
        }

        /// <summary>
        ///  Méthode qui change l'état de notre élément 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGoToLarge(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Large;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnGoToVisible(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Visible;
        }

        private void OnGoToCollapsed(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Collapsed;
        }
    }
}
