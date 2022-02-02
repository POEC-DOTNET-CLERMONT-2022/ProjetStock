using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockModels.JsonReader;
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
using ProjectStockModels.APIReader.Services;
using System.Net.Http;
using ProjectStockLibrary;

namespace WPF_Application.Market
{
    /// <summary>
    /// Logique d'interaction pour MarketListsControl.xaml
    /// </summary>
    public partial class MarketListsControl : UserControl
    {



        private readonly IGenericRepository<MarketEntity> _marketRepository = ((App)Application.Current).marketRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }

        private static ObservableCollection<MarketModel> _lists { get; } = new ObservableCollection<MarketModel>();

        public MarketLists MarketsLists { get; set; } = new MarketLists();

     

    
        public MarketListsControl()
        {
            InitializeComponent();
            jsonGenericReader = new MarketServiceReader(new HttpClient(), _mapper);
        }




        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadMarket();

        }

        public async void LoadMarket()
        {

            var userModels = await jsonGenericReader.GetAll();

            MarketsLists.Markets = new ObservableCollection<MarketModel>(userModels);


        }



        private async Task updateMarket( MarketModel market)
        {
            await jsonGenericReader.Update(market);

        }


        private async Task addMarket(MarketModel market)
        {
            await jsonGenericReader.Add(market);

        }



        private async Task deleteMarket(Guid id)
        {
          await jsonGenericReader.Delete(id);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var market = new MarketModel() { Id = Guid.NewGuid() , Name = TxtNom.Text, OpeningDate = DateTime.UtcNow, ClosingDate = DateTime.Now ,Stocks = new List<Stock>() };
            addMarket(market);


        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(TxtGuid.Text == null)
            {

                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            else
            {
                var market = new MarketModel() { Id = new Guid(TxtGuid.Text), Name = TxtNom.Text, OpeningDate = DateTime.UtcNow, ClosingDate = DateTime.Now ,Stocks = new List<Stock>()};
                updateMarket(market);

            }
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            if (TxtGuid.Text == null)
            {

                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            else
            {
                deleteMarket(new Guid(TxtGuid.Text));

            }

           

        }
    }
}
