using AutoMapper;
using ProjectStockDTOS;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using WPF_Application.UserControls.Forms;
using WPF_Application.Utils;

namespace WPF_Application.UserControls
{
    /// <summary>
    /// Logique d'interaction pour MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        private IMapper _mapper { get; set; } = ((App)Application.Current).Mapper;

        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }


        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();
        public MarketLists MarketLists { get; set; } = new MarketLists();




        private ObservableCollection<MarketModel> marketObservable { get; }
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }
        public MenuUserControl()
        {
            InitializeComponent();
            DataContext = this;
            HttpClient _client = new HttpClient();
            jsonGenericReader = new MarketServiceReader(_client, _mapper);
            LoadMarket();
        }


      

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadMarket();

        }

        public async void LoadMarket()
        {

            var userModels = await jsonGenericReader.GetAll();

            MarketLists.Markets = new ObservableCollection<MarketModel>(userModels);

            foreach (var item in userModels)
            {
                myList.Items.Add(new MenuItem() { Name = "test" , Header = item.Name.ToString() });
            }


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
            Navigator.NavigateTo(typeof(NotificationListsControl));

        
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

            Navigator.NavigateTo(typeof(OrderControl));
          
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

        private void Orders_click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(OrderControl));
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Addresses_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(OrderControl));
        }

    }
}
