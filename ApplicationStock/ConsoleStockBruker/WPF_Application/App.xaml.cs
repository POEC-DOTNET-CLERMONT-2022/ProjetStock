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

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IGenericRepository<UserEntity> userRepository { get; } = new GenericRepository<UserEntity>();


        public IMapper Mapper { get; }
        public App()
        {
            InitializeComponent();

                var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration); 
        }
    }
}
