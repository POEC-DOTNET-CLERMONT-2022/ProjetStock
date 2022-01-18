using AutoMapper;
using ProjectStockEntity;
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

namespace WPF_Application.Rappel
{
    /// <summary>
    /// Logique d'interaction pour NotificationListsControl.xaml
    /// </summary>
    public partial class NotificationListsControl : UserControl
    {

        private readonly IGenericRepository<NotificationEntity> _notifsRepository = ((App)Application.Current).notificationRepository;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public NotificationLists NotifsLists { get; set; } = new NotificationLists();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new NotificationModel() {  TextRappel  = TbUserName.Text };
            var notifEntity = _mapper.Map<NotificationEntity>(newOrder);
            _notifsRepository.Add(notifEntity);
            NotifsLists.Notifs.Add(newOrder);
            NotifsLists.Notifs.Add(newOrder);

            //UsersList.Users = new ObservableCollection<UserModel>();
        }

        public NotificationListsControl()

        {
            InitializeComponent();
            DataContext = NotifsLists;
            var orderModels = _mapper.Map<IEnumerable<NotificationModel>>(_notifsRepository.GetAll());
            NotifsLists.Notifs = new ObservableCollection<NotificationModel>(orderModels);
        }
       

    }
}
