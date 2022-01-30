

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
using System.Threading.Tasks;

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


        private async Task loadUser(JsonGenericReader<UserModel,UserDto> jsonGenericReader)
        {
                var result = await jsonGenericReader.GetAll();
                foreach (var item in result)
                    _lists.Add(item);
        }

        private async  Task updateUser(JsonGenericReader<UserModel, UserDto> jsonGenericReader, UserModel newUser)
        {
             await jsonGenericReader.Update(newUser);

        }

<<<<<<< HEAD
=======
        private async Task addUser(JsonGenericReader<UserModel,UserDto> jsonGenericReader, UserModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }


>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0
        private async Task deleteUser(JsonGenericReader<UserModel, UserDto> jsonGenericReader, Guid id)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
<<<<<<< HEAD
=======
            if(TxtGuid.Text != null)
            {
                var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = new Guid(TxtGuid.Text), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>(),ExpireToken = DateTime.Now,Token = "",Password = TxtPassword.Password,Siret = TbSriret.Text };
                updateUser(jsonGenericReader, newUser);
               
            }
      
>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0

         
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
<<<<<<< HEAD
            var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = new Guid(TxtGuid.Text), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>() };
            //addUser(jsonGenericReader,  newUser);
=======
            var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = Guid.NewGuid(), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>(), ExpireToken = DateTime.Now, Token = "", Password = TxtPassword.Password,Siret = TbSriret.Text };
            addUser(jsonGenericReader,  newUser);
            _lists.Add(newUser);
>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(TxtGuid.Text == null)
            {
                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                deleteUser(jsonGenericReader, new Guid(TxtGuid.Text));

            }
           
            
            
        }
    }
}
