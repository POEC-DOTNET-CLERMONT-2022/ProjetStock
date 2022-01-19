

using AutoMapper;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockModels;
using WPF_Application.Map;
using ProjectStockModels.Lists;
using ProjectStockRepository.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjectStockModels.JsonReader;
using ProjectStockDTOS;
using System.Net.Http;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.Model;

namespace WPF_Application.User
{
    /// <summary>
    /// Logique d'interaction pour UsersLists.xaml
    /// </summary>
    public partial class UsersLists : UserControl
    {

        private readonly IGenericRepository<UserEntity> _userRepository = ((App)Application.Current).userRepository;
        private readonly IMapper _mapper  = ((App)Application.Current).Mapper;

        private readonly JsonGenericReader<UserModel,UserDto> jsonGenericReader = new UserServiceReader(new HttpClient());

        public UsersList UsersList { get; set; } = new UsersList();

        public UsersLists()
        {
            InitializeComponent();
            DataContext = UsersList;
            var userModels = _mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll());
            UsersList.Users = new ObservableCollection<UserModel>(userModels);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserModel() { FirstName = TbUserName.Text };
            var userEntity = _mapper.Map<UserEntity>(newUser);
         
            jsonGenericReader.Add(newUser);
            UsersList.Users.Add(newUser);
            //UsersList.Users = new ObservableCollection<UserModel>();
        }
    }
}
