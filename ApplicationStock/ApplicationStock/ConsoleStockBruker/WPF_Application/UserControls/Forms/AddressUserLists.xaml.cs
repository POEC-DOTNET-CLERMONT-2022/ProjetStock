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
    /// Logique d'interaction pour AddressUserLists.xaml
    /// </summary>
    public partial class AddressUserLists : UserControl
    {
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public AddressLists StocksList { get; set; } = new AddressLists();
        public AddressUserLists()
        {
            InitializeComponent();
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
     
    }
}
