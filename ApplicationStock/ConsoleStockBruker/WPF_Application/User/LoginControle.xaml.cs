using ApiApplication.Models;
using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
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
using ProjectStockModels.APIReader.Services;

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour LoginControle.xaml
    /// </summary>
    public partial class LoginControle : UserControl
    {
      
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }

        public LoginControle()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(),_mapper);
        }

   

        private async Task Connect(AuthenticateRequest create)
        {

             await this.jsonGenericReader.Connect(create);
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser app_create = new CreateUser();
            userMenu.Content = app_create;
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            AuthenticateRequest app_create = new AuthenticateRequest();

            app_create._password = TxtPassword.Text;
            app_create._email = TxtEmail.Text;
            Connect(app_create);
        }
    }
}
