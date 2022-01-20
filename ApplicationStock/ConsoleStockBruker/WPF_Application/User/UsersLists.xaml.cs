

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

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }


        private static ObservableCollection<UserModel> _lists { get; set; }
        public UsersList UsersList { get; set; } = new UsersList();


        private async void loadUser(JsonGenericReader<UserModel,UserDto> jsonGenericReader)
        {
                var result = await jsonGenericReader.GetAll();
                foreach (var item in result)
                    _lists.Add(item);
        }

        private async  void updateUser(JsonGenericReader<UserModel, UserDto> jsonGenericReader, UserModel newUser)
        {
             await jsonGenericReader.Update(newUser);

        }

        private async void deleteUser(JsonGenericReader<UserModel, UserDto> jsonGenericReader, Guid id)
        {
            int _return = await jsonGenericReader.Delete(id);


            if(_return == 200)
            {
                //suppression de l'affichage
                foreach (var _item in _lists)
                {
                    if (_item.Id == id)
                    {
                        _lists.Remove(_item);
                        break;
                    }

                }
            }
           
           
        }

        public UsersLists()
        {
            InitializeComponent();
            DataContext = UsersList;
            jsonGenericReader = new UserServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<UserModel>();
            loadUser(jsonGenericReader);
            UsersList.Users = _lists;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _id = TxtGuid.Text;

            var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = new Guid(TxtGuid.Text), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>() };
            updateUser(jsonGenericReader, newUser);
           UsersList.Users.Add(newUser);
         
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var _id = TxtGuid.Text;
            var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = new Guid(TxtGuid.Text), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>() };
           //addUser(jsonGenericReader,  newUser);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            deleteUser(jsonGenericReader, new Guid(TxtGuid.Text));
            
        }
    }
}
