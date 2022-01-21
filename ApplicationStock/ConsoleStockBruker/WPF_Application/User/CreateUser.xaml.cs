using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl
    {
        private readonly IGenericRepository<UserEntity> _userRepository = ((App)Application.Current).userRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }
        public CreateUser()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(), _mapper);
        }
        private void login_button_create_Click(object sender, RoutedEventArgs e)
        {  
            userMenu.Content = null;
         ApiApplication.Models.CreateResult _user = new ApiApplication.Models.CreateResult();
            _user._firstName = "user";
            _user._lastName = "user";
            _user._password = TxtPassword.Text;
            _user._email = EMail.Text;
            try
            {
                Create(_user);
                LoginControle loginControle = new LoginControle();
                userMenu.Content = loginControle;

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void Create(ApiApplication.Models.CreateResult create)
        {
            try
            {
                var connection = await this.jsonGenericReader.CreateAccount(create);
            }catch (Exception ex)
            {
                MessageBox.Show("Erreur creation compte");
            }
            
        }

    }
}
