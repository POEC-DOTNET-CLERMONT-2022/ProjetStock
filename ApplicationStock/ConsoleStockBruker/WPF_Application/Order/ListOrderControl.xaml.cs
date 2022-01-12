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
            InitializeComponent();
            List<Order> _orders = new List<Order>();
            Stock stock = new Stock("CGI", 5, "CGI");
            _orders.Add(new Order("test_action",stock,5));
            Stock stock_ = new Stock("Apside", 5, "Apside");
            _orders.Add(new Order("test_action", stock_, 5));
            Stock stock_michelin = new Stock("Michelin", 5, "Michelin");
            _orders.Add(new Order("test_action", stock_michelin, 5));
            listsOrders.ItemsSource = _orders;
        }

    }
}
