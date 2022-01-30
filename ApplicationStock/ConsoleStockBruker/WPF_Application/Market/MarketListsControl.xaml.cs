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
            DataContext = MarketsLists;
            HttpClient _client = new HttpClient();
            jsonGenericReader = new MarketServiceReader(_client,_mapper);
            loadMarket(jsonGenericReader);
            MarketsLists.Markets = _lists;
        }


        private async Task loadMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader)
        {
            var result = await jsonGenericReader.GetAll();
            foreach (var item in result)
                _lists.Add(item);
        }

        private async Task updateMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader, MarketModel market)
        {
            await jsonGenericReader.Update(market);

        }


        private async Task addMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader, MarketModel market)
        {
            await jsonGenericReader.Add(market);

        }



        private async Task deleteMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader, Guid id)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var market = new MarketModel() { Id = Guid.NewGuid() , Name = TxtNom.Text, OpeningDate = DateTime.UtcNow, ClosingDate = DateTime.Now ,Stocks = new List<Stock>() };
            addMarket(jsonGenericReader, market);


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
                updateMarket(jsonGenericReader, market);

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
                deleteMarket(jsonGenericReader, new Guid(TxtGuid.Text));

            }

           

        }
    }
}
