using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Lists;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly IGenericRepository<NotificationEntity> _notifsRepository = ((App)Application.Current).notificationRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        private JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader { get; }
        private static ObservableCollection<NotificationModel> _lists { get; set; }
        public NotificationLists NotifsLists { get; set; } = new NotificationLists();
        public UserCreateRappelControle()
        {
            InitializeComponent();
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

        private async void addNotification(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader, NotificationModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }
    }
}
