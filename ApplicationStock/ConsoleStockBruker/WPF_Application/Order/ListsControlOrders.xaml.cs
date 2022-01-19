using AutoMapper;
using ProjectStockEntity;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_Application.Order
{
    /// <summary>
    /// Logique d'interaction pour ListsControlOrders.xaml
    /// </summary>
    public partial class ListsControlOrders : UserControl
    {
        private readonly IGenericRepository<OrderEntity> _orderRepository = ((App)Application.Current).orderRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public OrderLists OrderList { get; set; } = new OrderLists();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new OrderModel() { OrderName = TbUserName.Text };
            var userEntity = _mapper.Map<OrderEntity>(newOrder);
            _orderRepository.Add(userEntity);
            OrderList.Orders.Add(newOrder);

            //UsersList.Users = new ObservableCollection<UserModel>();
        }
        public ListsControlOrders()
        {

            InitializeComponent();
            DataContext = OrderList;
            var orderModels = _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetAll());
            OrderList.Orders = new ObservableCollection<OrderModel>(orderModels);

        }
    }
}
