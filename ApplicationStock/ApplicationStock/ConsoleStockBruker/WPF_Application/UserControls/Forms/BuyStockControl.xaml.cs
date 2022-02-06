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

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour BuyStockControl.xaml
    /// </summary>
    public partial class BuyStockControl : UserControl
    {

      
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }


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
    }
}
