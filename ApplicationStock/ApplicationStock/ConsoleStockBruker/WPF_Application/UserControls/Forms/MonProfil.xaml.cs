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




        private async void SendUser(Client user)
        {
           
            UserModel _user = _mapper.Map<UserModel>(user);
            _user.Id = new Guid(user.Id.ToString());
            _user._addresses = new List<Address>();

            var result = await _json.Update(_user);

            if( result == 200)
            {
                MessageBox.Show("Modifier","Modifier", MessageBoxButton.OK,MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Erreur","Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {


            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            BaseEntity entity = new BaseEntity();
            entity.Id = utilisateur.Id;
            Client _client = new Client(entity.Id);

            utilisateur.Id = utilisateur.Id;
            _client._lastName = TbNom.Text;
            _client._firstName = TbPrenom.Text;
            _client._password = TbPassword.Password;


            _client._email= TbEmail.Text;
            _client._addresses = new List<Address>();
            _client.setStocks(new List<Stock>());

            try
            {
                SendUser(_client);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            

        }
    }
}
