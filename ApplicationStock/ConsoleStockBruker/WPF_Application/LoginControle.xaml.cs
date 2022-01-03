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

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour LoginControle.xaml
    /// </summary>
    public partial class LoginControle : UserControl
    {
        public LoginControle()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Recover(object sender, RoutedEventArgs e)
        {
            SendMailReceoverPassword app_recover = new SendMailReceoverPassword();
            userMenu.Content = app_recover;

        }

        private void MenuItem_Click_Create(object sender, RoutedEventArgs e)
        {
            CreateUser app_user = new CreateUser();
            userMenu.Content = app_user;
        }
    }
}
