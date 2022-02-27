using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
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
using WPF_Application.Service.Interfaces;

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour AddressUserLists.xaml
    /// </summary>
    public partial class AddressUserLists : UserControl
    {
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public AddressLists StocksList { get; set; } = new AddressLists();

        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        private ObservableCollection<UserModel> _lists { get; set; }


        public AddressUserLists()
        {
            InitializeComponent();
            _json = new UserServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<UserModel>();
        }
        

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadAddress();

        }

        public async void LoadAddress()
        {
            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            var stocks = utilisateur._addresses;
          
            IEnumerable<AddressModel> userModels = _mapper.Map<IEnumerable<AddressModel>>(stocks);

            StocksList.Addresses = new ObservableCollection<AddressModel>(userModels);


        }



        private async Task setAddress(UserModel user, string message, string message_error)
        {

            var result = await _json.UpdateStocks(user,"/adresses");
            if(result == 200)
            {
                MessageBox.Show(message, message,MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(message_error, message_error,MessageBoxButton.OK,MessageBoxImage.Error);
            }



        }

     
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client = serviceUserAppCurrent.GetClientCurrent();


            var newAddress = new Address(TbAdress.Text, TbAddress2.Text, TbCp.Text, TbCity.Text, TbCountry.Text);

            client._addresses.Add(newAddress);
            var mapped = _mapper.Map<UserModel>(client);
            setAddress(mapped, "add addresses", "Error : addresses can not added");

           serviceUserAppCurrent.setClientCurrent(client);



        }


    }
}
