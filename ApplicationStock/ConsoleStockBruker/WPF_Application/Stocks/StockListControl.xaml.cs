using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
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
using WPF_Application.Utils;


namespace WPF_Application.Stocks
{
    /// <summary>
    /// Logique d'interaction pour StockListControl.xaml
    /// </summary>
    public partial class StockListControl : UserControl
    {
        private readonly IGenericRepository<StockEntity> _stockRepository = ((App)Application.Current).stockRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }


        private static ObservableCollection<StockModel> _lists { get; set; }
        public StockLists StocksList { get; set; } = new StockLists();


        private async Task loadStock(JsonGenericReader<StockModel, StockDto> jsonGenericReader)
        {
            var result = await jsonGenericReader.GetAll();
            foreach (var item in result)
                _lists.Add(item);
        }

        private async Task updateStock(JsonGenericReader<StockModel, StockDto> jsonGenericReader, StockModel newUser)
        {
            await jsonGenericReader.Update(newUser);

        }

        private async Task deleteStock(JsonGenericReader<StockModel, StockDto> jsonGenericReader, Guid id)
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

        public StockListControl()
        {
            InitializeComponent();
            DataContext = StocksList;
            jsonGenericReader = new StockServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<StockModel>();
            loadStock(jsonGenericReader);
            StocksList.Stocks = _lists;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var newUser = new StockModel() { Id = new Guid(TxtGuid.Text), EntrepriseName = TbEntrepriseName.Text, Value = int.Parse(TbValue.Text), Client = new List<Client>() };
            updateStock(jsonGenericReader, newUser);
            StocksList.Stocks.Add(newUser);

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var newUser = new StockModel() { Id = new Guid(TxtGuid.Text), EntrepriseName = TbEntrepriseName.Text,Value = int.Parse(TbValue.Text), Client = new List<Client>() };
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            deleteStock(jsonGenericReader, new Guid(TxtGuid.Text));

        }
    }

}
