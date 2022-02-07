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

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour MenuActionStockSell.xaml
    /// </summary>
    public partial class MenuActionStockSell : UserControl
    {

        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        
        public MenuActionStockSell()
        {
            InitializeComponent();
        }

        public void Buy_Click(object sender, EventArgs e)
        {
            Navigator.NavigateTo(typeof(BuyStockControl));
        }

        public void Sell_Click(object sender, EventArgs e)
        {
            Navigator.NavigateTo(typeof(SellStockControl));
        }
    }

}
