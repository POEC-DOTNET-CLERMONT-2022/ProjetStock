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
using WPF_Application.Model;
using WPF_Application.Order;
using WPF_Application.Rappel;
using WPF_Application.Stocks;
using WPF_Application.User;
using WPF_Application.UserControls;
using WPF_Application.Utils;

using WPF_Application.Model;
using WPF_Application.Market;
using System.Collections.ObjectModel;
using ProjectStockModels.Model;
using ProjectStockModels.JsonReader;
using ProjectStockDTOS;
using System.Net.Http;
using ProjectStockModels.APIReader.Services;
using AutoMapper;
using WPF_Application.Service.Interfaces;
using WPF_Application.Service.Services;
using WPF_Application.Buy_Sell;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;
        public Client User {private get; set;}

        public bool isLogged { get; set; } = false;

       

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public UsersList UsersList { get; set; } = new UsersList();

        private IMapper _mapper { get; set; } =   ((App)Application.Current).Mapper;


        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }


        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();
        public MarketLists MarketLists { get; set; }  = new MarketLists();



        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        private async Task loadMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader)
        {
            var result = await jsonGenericReader.GetAll();
            foreach (var item in result)
                myList.Items.Add(new MenuItem { Name = item._name, Header = item._name });


     


        }


        public MainWindow()
        {
            InitializeComponent();
            Navigator.NavigateTo(typeof(MarketDetailUC));
            Navigator.NavigateTo(typeof(StockDetailUC));

            HttpClient _client = new HttpClient();
            jsonGenericReader = new MarketServiceReader(_client, _mapper);
            //_lists = new ObservableCollection<MarketModel>();


            loadMarket(jsonGenericReader);

           
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

        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    ListsControlOrders app_list = new ListsControlOrders();
        //    user.Content = app_list;

        //}

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var test = serviceUserAppCurrent.GetClientCurrent();
            UsersLists app_lists_user = new UsersLists();
            user.Content = app_lists_user;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            NotificationListsControl _rappel = new NotificationListsControl();
            user.Content = _rappel;
        }
       

        private void MyNotification_Click(object sender, RoutedEventArgs e)
        {
            UserNotificationControle _user_rappel = new UserNotificationControle();
            user.Content = _user_rappel;
        }
        private void MenuBuy_Click(object sender, RoutedEventArgs e)
        {
            MenuSellBuy _menuSellBuy = new MenuSellBuy();
            user.Content = _menuSellBuy;
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
