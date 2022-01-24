using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
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

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour UserCommandeControl.xaml
    /// </summary>
    public partial class UserCommandeControl : UserControl
    {
        private readonly IGenericRepository<OrderEntity> _orderRepository = ((App)Application.Current).orderRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public OrderLists OrderList { get; set; } = new OrderLists();


        private JsonGenericReader<OrderModel, OrderDto> jsonGenericReader { get; }

        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        private static ObservableCollection<OrderModel> _lists { get; set; }
        private static ObservableCollection<StockModel> _listsStocks { get; set; }
        private async Task loadOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader)
        {
            Guid _id = Guid.NewGuid();
            var result = await jsonGenericReader.Get(_id);
          
                _lists.Add(result);
        }

        public UserCommandeControl()
        {
            InitializeComponent();
            DataContext = OrderList;
            jsonGenericReader = new OrderServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<OrderModel>();
            loadOrder(jsonGenericReader);
            OrderList.Orders = _lists;
        }

        private async Task updateOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader, OrderModel order)
        {
            await jsonGenericReader.Update(order);

        }

        private async Task deleteOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader, Guid id)
        {
            int _return = await jsonGenericReader.Delete(id);


            if (_return == 200)
            {
                //suppression de l'affichage
                foreach (var _item in _lists)
                {
                    if (_item.Id == id)
                    {
                        _lists.Remove(_item);
                        break;
                    }

                }
            }


        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            var newUser = new OrderModel() { Id = new Guid(TxtGuid.Text), OrderName = TxtNom.Text, NbStock = int.Parse(TxtQte.Text), Stock = new Stock() };
            updateOrder(jsonGenericReader, newUser);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            deleteOrder(jsonGenericReader, new Guid(TxtGuid.Text));

        }
     
    }
}
