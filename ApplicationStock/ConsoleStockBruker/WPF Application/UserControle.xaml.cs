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

namespace WPFStockControlLibrary
{
    /// <summary>
    /// Logique d'interaction pour UserControle.xaml
    /// </summary>
    public partial class UserControle : UserControl
    {
        public UserControle()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_Connection(object sender, RoutedEventArgs e)
        {
        
            LoginPage page_connection  = new LoginPage();

            page_connection.Show();
            
        }
        private void MenuItem_Click_Contact(object sender, RoutedEventArgs e)
        {

        }
    }
}
