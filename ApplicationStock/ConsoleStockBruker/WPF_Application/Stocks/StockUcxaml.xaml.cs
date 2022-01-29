using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPF_Application.Stocks
{
    /// <summary>
    /// Logique d'interaction pour StockUcxaml.xaml
    /// </summary>
    public partial class StockUcxaml : UserControl, INotifyPropertyChanged
    {
        public StockUcxaml()
        {
            InitializeComponent();
            userMenu.Content = null;
             StockModel _stock = new StockModel();
            _stock.EntrepriseName = TxtName.Text;
            _stock.Id = Guid.NewGuid();
            _stock.Value = int.Parse(TextValue.Text);  
            _stock._name = TxtName.Text;
            try
            {
                Create(_stock);
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private JsonGenericReader<StockModel, StockDto> jsonGenericReader { get; }

        private async Task Create(StockModel create)
        {
            try
            {
                await this.jsonGenericReader.Add(create);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur creation compte" + ex.ToString());
            }

        }
        private StockModel currentUser;
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

   
        public StockModel CurrentUser
        {
            get { return GetValue(CurrentUserProperty) as StockModel; }
            set
            {
                if (currentUser != value)
                {
                    SetValue(CurrentUserProperty, value);
                }
            }
        }

        private static readonly DependencyProperty CurrentUserProperty =
           DependencyProperty.Register("CurrentUser", typeof(StockUcxaml), typeof(StockUcxaml));

    

        public event PropertyChangedEventHandler? PropertyChanged;

        
        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Message box show");
        }
    }
}
