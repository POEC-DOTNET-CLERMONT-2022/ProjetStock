using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Application.Market;
using WPF_Application.Rappel;
using WPF_Application.Stocks;
using WPF_Application.User;
using WPF_Application.Utils;

namespace WPF_Application.UserControls
{
    /// <summary>
    /// Logique d'interaction pour MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public MenuUserControl()
        {
            InitializeComponent();
            DataContext = this;
        

        }


        private void MenuItem_Click_Contact(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(ContactUsControl));
        }

    
        //todo : nommage des méthodes 
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo(typeof(UsersLists));
         
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(NotificationListsControl));
         
        }


        private void MyNotification_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(UserNotificationControle));

        
        }
        private void MenuBuy_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(UserNotificationControle));
            
        }


        private void MenuItem_Click_Markets(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(MarketListsControl));
          
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo(typeof(StockListControl));
          
        }



        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(MonProfil));
          
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo(typeof(UserOrders));
          
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            //todo : utiliser la navigation avec le navigator 

            Navigator.NavigateTo(typeof(UserNotificationControle));
       
        }


        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            if (!Navigator.CanGoBack())
            {
                return;
            }
            Navigator.Back();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            //TODO : utile ? 
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
