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

using WCF_application.Services;

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour Gestion_lists_stocks.xaml
    /// </summary>
    public partial class Gestion_lists_stocks : UserControl
    {
        public Gestion_lists_stocks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _stocks = new ServiceStock();
            var stocks = _stocks.GetStocks();
            lists.ItemsSource= stocks;
        }
    }
}
