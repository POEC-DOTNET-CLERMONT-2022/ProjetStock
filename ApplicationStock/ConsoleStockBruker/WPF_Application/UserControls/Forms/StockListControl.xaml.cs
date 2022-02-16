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
using WPF_Application.Service.Interfaces;
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
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;
        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }


        private static ObservableCollection<StockModel> _lists { get; set; }
        public StockLists StocksList { get; set; } = new StockLists();


        public StockListControl()
         {
                InitializeComponent();
                jsonGenericReader = new StockServiceReader(new HttpClient(), _mapper);
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


        private async Task updateStock(StockModel newUser)
        {
            await jsonGenericReader.Update(newUser);


        }

        private async Task addStock(StockModel newUser)
        {

            await jsonGenericReader.Add(newUser);

        }

        private async Task deleteStock(Guid id)
        {
            await jsonGenericReader.Delete(id);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Client> _clients = new List<Client>();

            var newUser = new StockModel() { Id = Guid.NewGuid(), EntrepriseName = TbEntrepriseName.Text, Value = int.Parse(TbValue.Text), Name = TbNam.Text , Clients = _clients, ClientId = serviceUserAppCurrent.GetClientCurrent().Id };
            addStock( newUser);
            StocksList.Stocks.Add(newUser);

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
          

                var newUser = new StockModel() { Id = new Guid(TxtGuid.Text), EntrepriseName = TbEntrepriseName.Text, Value = int.Parse(TbValue.Text), Name = TbNam.Text, ClientId = serviceUserAppCurrent.GetClientCurrent().Id };
                
                updateStock(newUser);
               
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
                deleteStock(new Guid(TxtGuid.Text));
          
            

           

        }
    }

}
