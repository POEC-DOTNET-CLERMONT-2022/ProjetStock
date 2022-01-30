using ProjectStockLibrary;
using ProjectStockModels.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
<<<<<<< HEAD
=======
using WPF_Application.Model;
>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0
using WPF_Application.Order;
using WPF_Application.Rappel;
using WPF_Application.Stocks;
using WPF_Application.User;
using WPF_Application.UserControls;
using WPF_Application.Utils;

using WPF_Application.Model;
using WPF_Application.Market;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Client User {private get; set;}

        public bool isLogged { get; set; } = false;

       

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public UsersList UsersList { get; set; } = new UsersList();

        public MainWindow()
        {
            InitializeComponent();
            Navigator.NavigateTo(typeof(MarketDetailUC));
            Navigator.NavigateTo(typeof(StockDetailUC));


    

            LoginControle page_connection = new LoginControle();
            user.Content = page_connection;

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

<<<<<<< HEAD
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ListsControlOrders app_list = new ListsControlOrders();
            user.Content = app_list;
=======
        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    ListsControlOrders app_list = new ListsControlOrders();
        //    user.Content = app_list;
>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0

        //}

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


        private void MenuItem_Click_Markets(object sender, RoutedEventArgs e)
        {
            MarketListsControl _lists = new MarketListsControl();
           user.Content = _lists;
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

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Hidden;

            LoginControle _login = new LoginControle();
            user.Content = _login;
        }
    }
}
