using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
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

namespace WPF_Application.Rappel
{
    /// <summary>
    /// Logique d'interaction pour NotificationListsControl.xaml
    /// </summary>
    public partial class NotificationListsControl : UserControl
    {

        
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<NotificationModel,NotificationDto> jsonGenericReader { get; }
        private ObservableCollection<NotificationModel> _lists { get; set; }
        public NotificationLists NotifsLists { get; set; } = new NotificationLists();

        private IServiceUserAppCurrent serviceUserAppCurrent { get; } = ((App)Application.Current)._serviceUserApp;

        public NotificationListsControl()
        {
            InitializeComponent();
            jsonGenericReader = new NotificationServiceReader(new HttpClient(), _mapper);
        }




        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            LoadUser();

        }

        public async void LoadUser()
        {

            var userModels = await jsonGenericReader.GetAll();

            NotifsLists.Notifs = new ObservableCollection<NotificationModel>(userModels);


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var newUser = new NotificationModel() { Id = Guid.NewGuid(), SendAt = DateTime.Now, TextRappel = TbText.Text ,ClientId = serviceUserAppCurrent.GetClientCurrent().Id};
            addNotfi(newUser);
         

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (TxtGuid.Text.Length < 10|| TxtGuid.Text == null)
            {
                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                var newUser = new NotificationModel() { Id = Guid.NewGuid(), SendAt = DateTime.Now, TextRappel = TbText.Text,ClientId = serviceUserAppCurrent.GetClientCurrent().Id };
                updateUser(newUser);
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (TxtGuid.Text.Length < 10|| TxtGuid.Text == null)
            {
                MessageBox.Show("Erreur pas selectionner", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                deleteUser(new Guid(TxtGuid.Text));
            }
            

        }

        
        private async Task addNotfi( NotificationModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }

        
        private async Task  updateUser(NotificationModel newUser)
        {
            await jsonGenericReader.Update(newUser);

        }

        private async Task deleteUser(Guid id)
        {
           await jsonGenericReader.Delete(id);


        }


      

    
    }


}

