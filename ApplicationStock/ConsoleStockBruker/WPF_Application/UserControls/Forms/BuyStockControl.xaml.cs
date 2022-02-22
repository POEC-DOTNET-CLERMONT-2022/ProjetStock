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
using WPF_Application.Utils;

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour BuyStockControl.xaml
    /// </summary>
    public partial class BuyStockControl : UserControl
    {
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;


        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;


        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }

        private JsonGenericReader<OrderModel, OrderDto> json { get; set; }

        private JsonGenericReader<UserModel, UserDto> jsonUser { get; set; }

        private static ObservableCollection<StockModel> _lists { get; set; }

        public StockLists StocksList { get; set; } = new StockLists();

        public BuyStockControl()
        {
            InitializeComponent();
            HttpClient _client = new HttpClient();

            jsonGenericReader = new StockServiceReader(_client, _mapper);

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadStock();

        }
        public async void LoadStock()
        {
          
            var userModels = await jsonGenericReader.GetAll();

            StocksList.Stocks = new ObservableCollection<StockModel>(userModels);


        }


        private async void Buy_Click(object sender, RoutedEventArgs e)
        {


            HttpClient _client = new HttpClient();
            HttpClient _client2 = new HttpClient();

            jsonUser = new UserServiceReader(_client2, _mapper);

            json = new OrderServiceReader(_client, _mapper);

            var result = this.comboBox1.SelectedItem as StockModel;

           //var ordername = "Buy " + DateTime.Now.ToString() + " - " + serviceUserAppCurrent.GetGuid().ToString();
            
            var stock = new Stock(result.Name, result._value, result.EntrepriseName);
            stock.Id  = result.Id;
            stock.ClientId = serviceUserAppCurrent.GetGuid();

            var id = new Guid();
            var order = new OrderModel() { Id = id, OrderDate = DateTime.Now, OrderName = "Buy " + DateTime.Now.ToString() + " - " + serviceUserAppCurrent.GetGuid().ToString(), NbStock = 10, ClientId = serviceUserAppCurrent.GetClientCurrent().Id,Stock = new Stock()};
            order.Id = Guid.NewGuid();
           
            var resultat = await json.Add(order);
           if(resultat == 200)
            {
                Client client = serviceUserAppCurrent.GetClientCurrent();
                client.AddStocks(stock);

                var mapped_order = _mapper.Map<Order>(order);
                client._Orders.Add(mapped_order);

                UserModel model = _mapper.Map<UserModel>(client);
                await jsonUser.UpdateStocks(model,"/stocks");
                MessageBox.Show("Vous avez acheté une action", "Achat action", MessageBoxButton.OK,MessageBoxImage.Asterisk);

                serviceUserAppCurrent.setClientCurrent(client);
                Navigator.NavigateTo(typeof(MenuActionStockSell));
            }
            else
            {
                MessageBox.Show("erreur order", "erreur",MessageBoxButton.OK,MessageBoxImage.Error);
            }


        }
    }
}
