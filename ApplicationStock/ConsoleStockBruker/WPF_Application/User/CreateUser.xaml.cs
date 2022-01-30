using ApiApplication.Models;
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
       
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }
        public CreateUser()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(), _mapper);

            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            
        }
        private void login_button_create_Click(object sender, RoutedEventArgs e)
        {  
            userMenu.Content = null;
            ApiApplication.Models.CreateResult _user = new ApiApplication.Models.CreateResult();
            _user._firstName = "user";
            _user._lastName = "user";
            _user._password = TxtPassword.Password;


            _user._email = EMail.Text;
            try
            {
                Create(_user,sender);
                

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        private async Task Create(CreateResult create, object sender)
        {
            var result = await this.jsonGenericReader.CreateAccount(create);

            if (result == 200)
            {
                MessageBox.Show("Your account is not register", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
                this.loggedIn_Completed(sender, new EventArgs());

                
             

            }
            else
            {
                MessageBox.Show("Your account is not register", "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    
       
        private void loggedIn_Completed(object sender, EventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow._loginModalControl.Visibility = Visibility.Visible;
                LoginControle loginControle = new LoginControle();
                parentWindow.Content = loginControle;

               
            }
        }

    }
}
