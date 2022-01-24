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

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour UserCreateRappelControle.xaml
    /// </summary>
    public partial class UserCreateRappelControle : UserControl
    {
        
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader { get; }
        private ObservableCollection<NotificationModel> _lists { get; set; }
        public NotificationLists NotifsLists { get; set; } = new NotificationLists();
        public UserCreateRappelControle()
        {
            InitializeComponent();
            HttpClient _client = new HttpClient();
            jsonGenericReader = new NotificationServiceReader(new HttpClient(), _mapper);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var newUser = new NotificationModel() { Id = Guid.NewGuid(), SendAt = DateTime.Now.Add(TimeSpan.Parse(TxtDaysplUS.Text)), TextRappel = txtmessage.ToString() };
                addNotification(jsonGenericReader, newUser);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur ");
            }

        }

        private async Task addNotification(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader, NotificationModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }
    }
}
