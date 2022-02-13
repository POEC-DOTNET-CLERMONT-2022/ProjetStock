using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
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

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<OrderModel, OrderDto> jsonGenericReader { get; }


        public OrderLists OrdersList { get; set; } = new OrderLists();

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        public OrderControl()
        {
            InitializeComponent();
            jsonGenericReader = new OrderServiceReader(new HttpClient(), _mapper);
        }

    




        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadOrder();

        }

        public async void LoadOrder()
        {

            var userModels = await jsonGenericReader.GetAll();

            OrdersList.Orders = new ObservableCollection<OrderModel>(userModels);


        }


        private async Task updateOrder(OrderModel newUser)
        {
            await jsonGenericReader.Update(newUser);


        }

        private async Task addOrder(OrderModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }

        private async Task deleteOrder(Guid id)
        {
            await jsonGenericReader.Delete(id);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var newUser = new OrderModel() { Id = Guid.NewGuid(), OrderName = TbName.Text, OrderDate = DateTime.Now, Stock = new ProjectStockLibrary.Stock(), NbStock = 10, ClientId = serviceUserAppCurrent.GetClientCurrent().Id };
            addOrder(newUser);
            //OrdersList.Orders.Add(newUser);

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {


            var newUser = new OrderModel() { Id = new Guid(TxtGuid.Text), OrderName = TbName.Text, OrderDate = DateTime.Now, Stock = new ProjectStockLibrary.Stock(), NbStock = 10, ClientId = serviceUserAppCurrent.GetClientCurrent().Id };

            updateOrder(newUser);



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            deleteOrder(new Guid(TxtGuid.Text));





        }
     
    }
}
