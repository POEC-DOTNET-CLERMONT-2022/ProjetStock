using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
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
using WPF_Application.Service.Interfaces;

namespace WPF_Application.User
{
    /// <summary>
    /// Logique d'interaction pour UserOrders.xaml
    /// </summary>
    public partial class UserOrders : UserControl
    {

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public OrderLists OrderLists { get; set; } = new OrderLists();

        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        private ObservableCollection<OrderModel> _lists { get; set; }


        public UserOrders()
        {
            InitializeComponent();
            DataContext = this;
            _json = new UserServiceReader(new HttpClient(), _mapper);
        
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadAddress();

        }

        public async void LoadAddress()
        {
            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            var stocks = utilisateur._Orders;

            IEnumerable<OrderModel> userModels = _mapper.Map<IEnumerable<OrderModel>>(stocks);
            _lists = new ObservableCollection<OrderModel>(userModels); 
            OrderLists.Orders = _lists;


        }


    }
}
