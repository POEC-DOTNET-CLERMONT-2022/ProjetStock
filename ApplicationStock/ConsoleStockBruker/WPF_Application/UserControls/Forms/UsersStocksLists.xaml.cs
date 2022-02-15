using AutoMapper;
using ProjectStockLibrary;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
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
using WPF_Application.Service.Interfaces;

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour UsersStocksLists.xaml
    /// </summary>
    public partial class UsersStocksLists : UserControl
    {
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public UsersStocksLists()
        {
            InitializeComponent();
        }
        public StockLists StocksList { get; set; } = new StockLists();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadStock();

        }

        public async void LoadStock()
        {
            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            var stocks = new List<Stock>();

            utilisateur._stocks.ToList().ForEach(x => stocks.Add(x));
            IEnumerable<StockModel> userModels = _mapper.Map<IEnumerable<StockModel>>(stocks);          

            StocksList.Stocks = new ObservableCollection<StockModel>(userModels);


        }
    }
}
