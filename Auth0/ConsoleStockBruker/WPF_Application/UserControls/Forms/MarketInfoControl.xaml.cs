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
using System.Threading;
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
    /// Logique d'interaction pour MarketInfoControl.xaml
    /// </summary>
    public partial class MarketInfoControl : UserControl
    {
        private static ObservableCollection<MarketModel> _lists { get; } = new ObservableCollection<MarketModel>();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }

        public MarketLists MarketsLists { get; set; } = new MarketLists();


        public static Guid marketGuid { get; set; } 
        public MarketInfoControl()
        {
            InitializeComponent();

            jsonGenericReader = new MarketServiceReader(new HttpClient(), _mapper);
            marketGuid = Guid.NewGuid();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadMarket();

        }

        public async void LoadMarket()
        {
            var userModels = await jsonGenericReader.GetAll();
            MarketsLists.Market = userModels.Where(x => x.Id == marketGuid).FirstOrDefault();


        }
    }
}
