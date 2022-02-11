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
using WPF_Application.Utils;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl
    {

       
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }
        public CreateUser()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(), _mapper);

            
        }



        public bool CheckEmail(string email)
        {
            try 
            { 
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        
        

        private void button_create_Click(object sender, RoutedEventArgs e)
        {  
            userMenu.Content = null;
            ApiApplication.Models.CreateResult _user = new ApiApplication.Models.CreateResult();
            _user._firstName = TbLastName.Text;
            _user._lastName = TbName.Text;
            _user._email = Tbemail.Text;
            _user._password = TxtPassword.Password;

            try
            {
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (this.CheckEmail(_user._email))
                {
                    Create(_user, sender);
                }
                else
                {
                    throw new Exception("Erreur email");
                }

                    

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,ex.Message.ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }




        private async Task Create(CreateResult create, object sender)
        {
            var result = await this.jsonGenericReader.CreateAccount(create);

            if (result == 200)
            {
                MessageBox.Show("Your account is register", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigator.NavigateTo(typeof(LoginControle));
            }
            else
            {
                MessageBox.Show("Your account is not register", "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    
       
     

    }
}
