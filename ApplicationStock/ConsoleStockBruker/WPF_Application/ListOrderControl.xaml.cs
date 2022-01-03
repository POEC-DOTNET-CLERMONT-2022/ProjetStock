using ProjectStockLibrary;
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
    /// Logique d'interaction pour ListOrderControl.xaml
    /// </summary>
    public partial class ListOrderControl : UserControl
    {
        
        public ListOrderControl()
        {
            //List<Order> _orders = new List<Order>();
            //Stock stock = new Stock("etst", 5, "tests");
            //_orders.Add(new Order("testc",stock , 5));


            //listsOrders.ItemsSource = _items;


            InitializeComponent();
        }

        private void ChangeViewOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
