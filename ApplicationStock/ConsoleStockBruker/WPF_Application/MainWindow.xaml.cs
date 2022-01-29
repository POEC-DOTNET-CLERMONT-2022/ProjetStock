using ProjectStockModels.Lists;
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
using WPF_Application.Order;
using WPF_Application.Rappel;
using WPF_Application.Stocks;
using WPF_Application.User;
using WPF_Application.UserControls;
using WPF_Application.Utils;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public UsersList UsersList { get; set; } = new UsersList();

        public MainWindow()
        {
            InitializeComponent();
            Navigator.NavigateTo(typeof(MarketDetailUC));
            Navigator.NavigateTo(typeof(StockDetailUC));
        
        }


        private void MenuItem_Click_Connection(object sender, RoutedEventArgs e)
        {

            LoginControle page_connection = new LoginControle();
            user.Content = page_connection;


        }
        private void MenuItem_Click_Contact(object sender, RoutedEventArgs e)
        {
            ContactUsControl app_contact = new ContactUsControl();
            user.Content = app_contact;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ListsControlOrders app_list = new ListsControlOrders();
            user.Content = app_list;

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            UsersLists app_lists_user = new UsersLists();
            user.Content = app_lists_user;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            NotificationListsControl _rappel = new NotificationListsControl();
            user.Content = _rappel;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StockListControl _listStock = new StockListControl();
            user.Content = _listStock;
        }

        private void DisplayDetailClick(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(StockUcxaml));
        }


        private void Profile_click(object sender, RoutedEventArgs e)
        {
            MonProfil _profil = new MonProfil();
            user.Content = _profil;
        }

        private void Orders_click(object sender, RoutedEventArgs e)
        {
            UserOrders _orders = new UserOrders();
            user.Content = _orders;
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            UserNotificationControle _userNotifs = new UserNotificationControle();
            user.Content = _userNotifs;
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            if (!Navigator.CanGoBack())
            {
                return;
            }
            Navigator.Back();
        }

       
    }
}
