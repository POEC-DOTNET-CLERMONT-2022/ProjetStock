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

        private async Task loadUser(JsonGenericReader<UserModel, UserDto> _json, string email)
        {
            var result = await _json.GetByEmail(email);
            _lists.Add(result);

            TbEmail.Text = _lists[0].Email;
            TbNom.Text = _lists[0].LastName;
           
        }
        public MonProfil()
        {
            InitializeComponent();
          
            _json= new UserServiceReader(new HttpClient(), _mapper);
            _lists = new ObservableCollection<UserModel>();
            Client client = serviceUserAppCurrent.GetClientCurrent();
            loadUser(_json, client._email);
     
        }
    }
}
