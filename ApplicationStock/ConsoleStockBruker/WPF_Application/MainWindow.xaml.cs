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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_Connection(object sender, RoutedEventArgs e)
        {

            LoginControle page_connection = new LoginControle();
            user.Content = page_connection;


        }
        private void MenuItem_Click_Contact(object sender, RoutedEventArgs e)
        {
            ContactUsControl app_contact = new ContactUsControl();
            user.Content = app_contact;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ListOrderControl app_list = new ListOrderControl();
            user.Content = app_list;

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Gestion_lists_stocks app_list_stocks = new Gestion_lists_stocks();
            user.Content = app_list_stocks;
        }
    }
}
