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

namespace WPF_Application.Order
{
    /// <summary>
    /// Logique d'interaction pour ListsControlOrders.xaml
    /// </summary>
    public partial class ListsControlOrders : UserControl
    {
        
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public OrderLists OrderLists { get; set; } = new OrderLists();


        private JsonGenericReader<OrderModel, OrderDto> jsonGenericReader { get; }


        private static ObservableCollection<OrderModel> _lists { get; set; }
        private async Task loadOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader)
        {
            var result = await jsonGenericReader.GetAll();
            foreach (var item in result)
                
                _lists.Add(item);
        }


        public ListsControlOrders()
        {
            InitializeComponent();
            DataContext = OrderLists;
            jsonGenericReader = new OrderServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<OrderModel>();
            loadOrder(jsonGenericReader);
            OrderLists.Orders = _lists;
        }

       

        private async Task updateOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader, OrderModel order)
        {
            await jsonGenericReader.Update(order);

        }

        private async Task  deleteOrder(JsonGenericReader<OrderModel, OrderDto> jsonGenericReader, Guid id)
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
            updateOrder(jsonGenericReader,  newUser);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            deleteOrder(jsonGenericReader, new Guid(TxtGuid.Text));

        }
    }
}
