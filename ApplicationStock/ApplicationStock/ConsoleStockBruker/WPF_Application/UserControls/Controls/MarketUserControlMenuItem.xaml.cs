﻿using AutoMapper;
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
using WPF_Application.Utils;

namespace WPF_Application.UserControls.Controls
{
    /// <summary>
    /// Logique d'interaction pour MarketUserControlMenuItem.xaml
    /// </summary>
    public partial class MarketUserControlMenuItem : UserControl
    {

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;


        private IMapper _mapper { get; set; } = ((App)Application.Current).Mapper;

        private JsonGenericReader<MarketModel, MarketDto> jsonGenericReader { get; }


        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();
        public MarketLists MarketLists { get; set; } = new MarketLists();



        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        private async Task loadMarket(JsonGenericReader<MarketModel, MarketDto> jsonGenericReader)
        {
            //var result = await jsonGenericReader.GetAll();
            //foreach (var item in result)
            //   myList.Items.Add(new MenuItem { Name = item._name, Header = item._name });

          

        }

        public MarketUserControlMenuItem()
        {
            InitializeComponent();
            HttpClient _client = new HttpClient();
            jsonGenericReader = new MarketServiceReader(_client, _mapper);
            loadMarket(jsonGenericReader);

        }
    }
}
