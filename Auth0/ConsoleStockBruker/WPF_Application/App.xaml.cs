using AutoMapper;
using ProjectStockEntity;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjectStockRepository.Repository;
using ProjectStockLibrary;
using WPF_Application.Utils;
using WPF_Application.Stocks;
using WPF_Application.UserControls;
using WPF_Application.Service.Interfaces;
using WPF_Application.Service.Services;
using WPF_Application.User;
using WPF_Application.UserControls.Controls;
using WPF_Application.Rappel;
using WPF_Application.Market;
using WPF_Application.UserControls.Forms;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        public INavigator Navigator { get; } = new Navigator();

        
        public IServiceUserAppCurrent _serviceUserApp { get; set; } = new ServiceClientCurrent();

        public IGenericRepository<UserEntity> userRepository { get; } = new GenericRepository<UserEntity>();

        public IGenericRepository<OrderEntity> orderRepository { get;} = new GenericRepository<OrderEntity>();


        public IGenericRepository<StockEntity> stockRepository { get; } = new GenericRepository<StockEntity>();

        public IGenericRepository<NotificationEntity> notificationRepository { get; } = new GenericRepository<NotificationEntity>();

        public IGenericRepository<MarketEntity> marketRepository { get; } = new GenericRepository<MarketEntity>();
        

        public IGenericRepository<AddressEntity> addressEntity { get; } = new   GenericRepository<AddressEntity>();

        public IMapper Mapper { get; }
        public App()
        {
          

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
           

        }


        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Navigator.RegisterView(new LoginControle());
            Navigator.RegisterView(new MarketUserControlMenuItem());
            Navigator.RegisterView(new UserMainWindowsConnected());
            Navigator.RegisterView(new MenuUserControl());
            Navigator.RegisterView(new MonProfil());
            Navigator.RegisterView(new UsersLists());
            Navigator.RegisterView(new CreateUser());
           
            Navigator.RegisterView(new ContactUsControl());
            Navigator.RegisterView(new StockListControl());
            Navigator.RegisterView(new NotificationListsControl());
            Navigator.RegisterView(new MarketListsControl());
            Navigator.RegisterView(new OrderControl());
            Navigator.RegisterView(new MarketInfoControl());
            Navigator.RegisterView(new StockInfoControl());
            Navigator.RegisterView(new MenuActionStockSell());
            Navigator.RegisterView(new BuyStockControl());
            Navigator.RegisterView(new SellStockControl());
            Navigator.RegisterView(new UsersStocksLists());
            Navigator.RegisterView(new AddressUserLists());
            Navigator.RegisterView(new UsersNotifications());
            Navigator.RegisterView(new UserOrders());
        }





    }
}
