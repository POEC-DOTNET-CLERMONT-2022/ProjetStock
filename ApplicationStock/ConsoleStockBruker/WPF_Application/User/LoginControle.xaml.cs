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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjectStockLibrary;
using Newtonsoft.Json;
using WPF_Application.Service.Interfaces;
using Newtonsoft.Json.Linq;

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour LoginControle.xaml
    /// </summary>
    public partial class LoginControle : UserControl
    {

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        private JsonGenericReader<UserModel, UserDto> jsonGenericReader { get; }

        public LoginControle()
        {
            InitializeComponent();
            jsonGenericReader = new UserServiceReader(new HttpClient(),_mapper);
          
        }


    
        private async Task loadUser(AuthenticateRequest authenticate,object sender)
        {
            var result = await this.jsonGenericReader.Connect(authenticate);


            var object_result = await result.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(object_result);


            var mapped = _mapper.Map<Client>(jObject);
          

            serviceUserAppCurrent.setClientCurrent(mapped);


            if ((int) result.StatusCode == 200)
            {


                MessageBox.Show("You are connected", "Connected", MessageBoxButton.OK, MessageBoxImage.Information);
     
                
                this.loggedIn_Completed(sender, new EventArgs());

            }
            else
            {
                MessageBox.Show("You are not connected", "Not Connected", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private async Task<Client> loadUserInfo(string email)
        {

           
            var result = await this.jsonGenericReader.GetByEmail(email);

          
            var mapped_ = _mapper.Map<Client>(result);
            return mapped_;
        }



        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            CreateUser app_create = new CreateUser();

            
            parentWindow.Content = app_create;
           
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {

            //try
            //{

                AuthenticateRequest app_create = new AuthenticateRequest();

                app_create._password = TxtPassword.Password;
                app_create._email = TxtEmail.Text;
                loadUser(app_create,sender);

             
  

                
            //}
            //catch(Exception ew)
            //{
            //    MessageBox.Show("Informations invalids" + ew.ToString(),"Error",MessageBoxButton.OK, MessageBoxImage.Error);
            //}


        }

        private void loggedIn_Completed(object sender, EventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow._loginModalControl.Visibility = Visibility.Visible;
               
          
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
