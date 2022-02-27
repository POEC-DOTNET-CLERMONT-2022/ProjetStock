using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
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

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour UsersNotifications.xaml
    /// </summary>
    public partial class UsersNotifications : UserControl
    {
      

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<UserModel, UserDto> _json { get; set; }
        public UsersNotifications()
    {
            InitializeComponent();
            _json = new UserServiceReader(new HttpClient(), _mapper);
        }
        public NotificationLists NotifsLists{ get; set; } = new NotificationLists();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadStock();

        }

        public async void LoadStock()
        {
            Client utilisateur = serviceUserAppCurrent.GetClientCurrent();
            var stocks = utilisateur._notifications;



            List<NotificationModel> userModels = new List<NotificationModel>();

            stocks.ToList().ForEach(stock => userModels.Add(_mapper.Map<NotificationModel>(stock)));
                

            NotifsLists.Notifs = new ObservableCollection<NotificationModel>(userModels);


        }

        private async Task setAddress(UserModel user, string message, string message_error)
        {

            var result = await _json.UpdateStocks(user, "/notifs");
            if (result == 200)
            {
                MessageBox.Show(message, message, MessageBoxButton.OK, MessageBoxImage.Information);
                var _client = _mapper.Map<Client>(user);
                serviceUserAppCurrent.setClientCurrent(_client);
            }
            else
            {
                MessageBox.Show(message_error, message_error, MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client = serviceUserAppCurrent.GetClientCurrent();

            Notification notification = new Notification() { Id= Guid.NewGuid(),_textRappel = TbText.Text,_sendAt = DateTime.Now,ClientId = serviceUserAppCurrent.GetClientCurrent().Id};

            client._notifications.Add(notification);
            var mapped = _mapper.Map<UserModel>(client);


            mapped._notifs =  _mapper.Map<List<Notification>>(client._notifications);
            setAddress(mapped, "add notif", "Error : notifs can not added");

          



        }

    }
}
