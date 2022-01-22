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

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour MonProfil.xaml
    /// </summary>
    public partial class MonProfil : UserControl
    {

        private readonly IGenericRepository<UserEntity> _userRepository = ((App)Application.Current).userRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        private static ObservableCollection<UserModel> _lists { get; set; }

        private async void loadUser(JsonGenericReader<UserModel, UserDto> _json, Guid id)
        {
            var result = await _json.Get(id);
            _lists.Add(result);
        }
        public MonProfil()
        {
            InitializeComponent();
          
            _json= new UserServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<UserModel>();
            Guid _id = Guid.NewGuid();
            loadUser(_json,_id);
     
        }
    }
}
