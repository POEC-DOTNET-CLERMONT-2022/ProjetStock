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


        public NotificationListsControl()

        {
            InitializeComponent();
            DataContext = NotifsLists;
            jsonGenericReader = new NotificationServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<NotificationModel>();
            loadNotif(jsonGenericReader);
         
                NotifsLists.Notifs = _lists;
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var newUser = new NotificationModel() { Id = Guid.NewGuid(), SendAt = DateTime.Now, TextRappel = TbText.Text };
            addUser(jsonGenericReader, newUser);
         

        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
            var newUser = new NotificationModel() { Id = Guid.NewGuid(), SendAt = DateTime.Now, TextRappel = TbText.Text };
            updateUser(jsonGenericReader,  newUser);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            deleteUser(jsonGenericReader, new Guid(TxtGuid.Text));

        }


        private async Task loadNotif(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader)
        {
            try
            {
                var result = await jsonGenericReader.GetAll();
                foreach (var item in result)
                    _lists.Add(item);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private async Task addUser(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader, NotificationModel newUser)
        {
            await jsonGenericReader.Add(newUser);

        }


        private async Task  updateUser(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader, NotificationModel newUser)
        {
            await jsonGenericReader.Update(newUser);

        }

        private async Task deleteUser(JsonGenericReader<NotificationModel, NotificationDto> jsonGenericReader, Guid id)
        {
            int _return = await jsonGenericReader.Delete(id);


            if (_return == 200)
            {
                //suppression de l'affichage
                foreach (var _item in _lists)
                {
                    if (_item.Id == id)
                    {
                        _lists.Remove(_item);
                        break;
                    }

                }
            }


        }


      

    
    }


}

