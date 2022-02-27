using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPF_Application.Service.Interfaces;
using BaseEntity = ProjectStockLibrary.BaseEntity;

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour MonProfil.xaml
    /// </summary>
    public partial class MonProfil : UserControl
    {
        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        private ObservableCollection<UserModel> _lists { get; set; }

        private Client utilisateur { get; set; }


        private Client _client { get; set; }
    

        public MonProfil()
        {
            InitializeComponent();
          
            _json= new UserServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<UserModel>();

        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadUser();
        }

        private async void LoadUser()
        {
              Client utilisateur = serviceUserAppCurrent.GetClientCurrent();


            TbEmail.Text = utilisateur._email;
            TbNom.Text = utilisateur._lastName;
            TbPrenom.Text = utilisateur._firstName;
        }




        private async void SendUser(UserModel user)
        {
           
   
            var result = await _json.Update(user);

            if( result == 200)
            {
                MessageBox.Show("Les informations de votre compte ont été modifiés ","Les informations de votre compte ont été modifiés", MessageBoxButton.OK,MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Erreur de la modification de vos informations","Une erreur est survenue lors de la modification de vos informations", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {


            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            var date = DateTime.Now;
            var date_changed = date.AddDays(30);
    
            var newUser = new UserModel() { FirstName = TbPrenom.Text, Id = utilisateur.Id, LastName = TbNom.Text, Email = TbEmail.Text, Phone = "888", Addresses = new List<Address>(), Stocks = new List<Stock>(), ExpireToken = date_changed, Token = utilisateur._token, Password = TbPassword.Password, Siret = "test" };
          



            try
            {
                SendUser(newUser);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            

        }
    }
}
