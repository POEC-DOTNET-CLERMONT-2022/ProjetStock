using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
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

namespace WPF_Application.Market
{
    /// <summary>
    /// Logique d'interaction pour MarketCreateControl.xaml
    /// </summary>
    public partial class MarketCreateControl : UserControl
    {
        private readonly IGenericRepository<MarketEntity> _marketRepository = ((App)Application.Current).marketRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<MarketModel, MarketDto> _json{ get; }
        private static ObservableCollection<MarketModel> _lists { get; set; }
       
        public MarketCreateControl()
        {
            InitializeComponent();
            HttpClient _client = new HttpClient();
            _json = new MarketServiceReader(_client, _mapper);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var _market = new MarketModel() { Id = Guid.NewGuid(), Name = "test", ClosingDate = DateTime.Now, _closingDate = DateTime.Now.AddHours(8) };
                addMarket(_json, _market);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ");
            }

        }

        private async void addMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader, MarketModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }
    }
}
