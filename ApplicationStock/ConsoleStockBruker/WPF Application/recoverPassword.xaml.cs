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
using System.Windows.Shapes;

namespace WPFStockControlLibrary
{
    /// <summary>
    /// Logique d'interaction pour recoverPassword.xaml
    /// </summary>
    public partial class recoverPassword : Window
    {
        public recoverPassword()
        {
            InitializeComponent();
            UserControle userControle = new UserControle();
            userMenu.Content = userControle;
        }
        private void login_button_recover_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
