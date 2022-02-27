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
    /// Logique d'interaction pour StockInfoControl.xaml
    /// </summary>
    public partial class StockInfoControl : UserControl
    {
        private static ObservableCollection<StockModel> _lists { get; } = new ObservableCollection<StockModel>();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }
        public static Guid stockGuid { get; set; }

        public StockLists StockLists { get; set; } = new StockLists();

        public StockInfoControl()
        {
            InitializeComponent();
            HttpClient _client = new HttpClient();
            jsonGenericReader = new StockServiceReader(new HttpClient(), _mapper);
            stockGuid = Guid.NewGuid();
        }
     

     
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadStock();

        }

        public async void LoadStock()
        {
            var userModels = await jsonGenericReader.GetAll();

            StockLists.Stock = userModels.Where(x => x.Id == stockGuid).FirstOrDefault();


        }
    }
}
