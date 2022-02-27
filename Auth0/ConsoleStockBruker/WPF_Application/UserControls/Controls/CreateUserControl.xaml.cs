using System;
using System.Collections.Generic;
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
using WPF_Application.Utils;

namespace WPF_Application.UserControls.Controls
{
    /// <summary>
    /// Logique d'interaction pour CreateUserControl.xaml
    /// </summary>
    public partial class CreateUserControl : UserControl
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public CreateUserControl()
        {
            InitializeComponent();
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(CreateUser));

        }
    }
}
