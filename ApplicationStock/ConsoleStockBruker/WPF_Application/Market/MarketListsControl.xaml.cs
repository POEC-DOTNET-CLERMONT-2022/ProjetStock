using AutoMapper;
using ProjectStockEntity;
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

namespace WPF_Application.Market
{
    /// <summary>
    /// Logique d'interaction pour MarketListsControl.xaml
    /// </summary>
    public partial class MarketListsControl : UserControl
    {



        private readonly IGenericRepository<MarketEntity> _marketRepository = ((App)Application.Current).marketRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public MarketLists MarketsLists { get; set; } = new MarketLists();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new MarketModel() {Name = TbUserName.Text };
            var notifEntity = _mapper.Map<MarketEntity>(newOrder);
            _marketRepository.Add(notifEntity);
            MarketsLists.Markets.Add(newOrder);


            //UsersList.Users = new ObservableCollection<UserModel>();
        }

        public MarketListsControl()

        {
            InitializeComponent();
            DataContext = MarketsLists;
            var orderModels = _mapper.Map<IEnumerable<MarketModel>>(_marketRepository.GetAll());
            MarketsLists.Markets = new ObservableCollection<MarketModel>(orderModels);
        }
        
    }
}
