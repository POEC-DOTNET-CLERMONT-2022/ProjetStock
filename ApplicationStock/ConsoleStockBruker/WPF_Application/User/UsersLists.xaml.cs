

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
using System;

namespace WPF_Application.User
{
    /// <summary>
    /// Logique d'interaction pour UsersLists.xaml
    /// </summary>
    public partial class UsersLists : UserControl
    {

        private readonly IGenericRepository<UserEntity> _userRepository = ((App)Application.Current).userRepository;
        private readonly IMapper _mapper  = ((App)Application.Current).Mapper;

        private readonly JsonGenericReader<UserModel, UserDto> jsonGenericReader;
        public UsersList UsersList { get; set; } = new UsersList();

        public UsersLists()
        {
            InitializeComponent();
            DataContext = UsersList;
            var userModels = _mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll());
            jsonGenericReader = new UserServiceReader(new HttpClient(), this._mapper);
           // var valeur = jsonGenericReader.GetAll();
            UsersList.Users = new ObservableCollection<UserModel>(userModels);
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserModel() { FirstName = TbUserName.Text, Id = Guid.NewGuid(), LastName = TbUserName.Text, Email = "gsg@gmail.fr",Phone="test" };
            
            jsonGenericReader.Add(newUser);
            UsersList.Users.Add(newUser);
            //UsersList.Users = new ObservableCollection<UserModel>();
        }
    }
}
