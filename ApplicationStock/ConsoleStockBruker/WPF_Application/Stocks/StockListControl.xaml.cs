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

namespace WPF_Application.Stocks
{
    /// <summary>
    /// Logique d'interaction pour StockListControl.xaml
    /// </summary>
    public partial class StockListControl : UserControl
    {
        private readonly IGenericRepository<StockEntity> _stockRepository = ((App)Application.Current).stockRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public StockLists StockList { get; set; } = new StockLists();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new StockModel() { EntrepriseName = TbUserName.Text };
            var stockEntity = _mapper.Map<StockEntity>(newOrder);
            _stockRepository.Add(stockEntity);
            StockList.Stocks.Add(newOrder);

            //UsersList.Users = new ObservableCollection<UserModel>();
        }
        public StockListControl()
        {
            
                InitializeComponent();
                DataContext = StockList;
                var stockModels = _mapper.Map<IEnumerable<StockModel>>(_stockRepository.GetAll());
                StockList.Stocks = new ObservableCollection<OrderModel>(stockModels);
            }
        }
}
