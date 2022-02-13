using ProjectStockLibrary;
using ProjectStockModels.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_Application.Model;
using WPF_Application.Rappel;
using WPF_Application.Stocks;
using WPF_Application.User;
using WPF_Application.UserControls;
using WPF_Application.Utils;

using WPF_Application.Model;
using WPF_Application.Market;
using System.Collections.ObjectModel;
using ProjectStockModels.Model;
using ProjectStockModels.JsonReader;
using ProjectStockDTOS;
using System.Net.Http;
using ProjectStockModels.APIReader.Services;
using AutoMapper;
using WPF_Application.Service.Interfaces;
using WPF_Application.Service.Services;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;
        public Client User {private get; set;}

        public bool isLogged { get; set; } = false;

       

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public AddressList UsersList { get; set; } = new AddressList();

        public OrderLists OrdersLists { get; set; } = new OrderLists();

        private IMapper _mapper { get; set; } =   ((App)Application.Current).Mapper;


        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }


   
        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;
            
            Navigator.NavigateTo(typeof(LoginControle));


        }


     


    }
}
