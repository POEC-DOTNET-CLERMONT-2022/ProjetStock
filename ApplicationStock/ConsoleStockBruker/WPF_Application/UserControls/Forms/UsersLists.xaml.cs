

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
using WPF_Application.Utils;

namespace WPF_Application.User
{
    /// <summary>
    /// Logique d'interaction pour UsersLists.xaml
    /// </summary>
    ///
   
    public partial class UsersLists : UserControl
    {

        private readonly IGenericRepository<UserEntity> _userRepository = ((App)Application.Current).userRepository;
        private readonly IMapper _mapper  = ((App)Application.Current).Mapper;

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }


        private static ObservableCollection<UserModel> _lists { get; set; }
        public AddressList UsersList { get; set; } = new AddressList();



        private async  Task updateUser(UserModel newUser)
        {
             await jsonGenericReader.Update(newUser);

        }

        private async Task addUser(UserModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }


        private async Task deleteUser(Guid id)
        {
            await jsonGenericReader.Delete(id); 
           
        }

        public UsersLists()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(), _mapper);
        }




        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadUser();
          
        }

        public async void LoadUser()
        {
 
            var userModels = await jsonGenericReader.GetAll();

            UsersList.Users = new ObservableCollection<UserModel>(userModels);
          
           
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
            if(TxtGuid.Text != null)
            {
                var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = new Guid(TxtGuid.Text), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>(), ExpireToken = DateTime.Now, Token = "", Password = TxtPassword.Password, Siret = TbSriret.Text, };
                updateUser(newUser);
               
            }
      

         
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            var newUser = new UserModel() { FirstName = TbUserFirstName.Text, Id = Guid.NewGuid(), LastName = TbUserName.Text, Email = TbEmail.Text, Phone = TbPhone.Text, Addresses = new List<Address>(), Stocks = new List<Stock>(), ExpireToken = DateTime.Now, Token = "", Password = TxtPassword.Password, Siret = TbSriret.Text };

            addUser(newUser);
            UsersList.Users.Add(newUser);
         

            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if(TxtGuid.Text == null)
            {
                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                deleteUser(new Guid(TxtGuid.Text));

            }
           
            
            
        }
    }
}
