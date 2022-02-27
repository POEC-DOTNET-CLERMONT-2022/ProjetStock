using ProjectStockModels.Model;
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

namespace WPF_Application.UserControls.Controls
{
    /// <summary>
    /// Logique d'interaction pour MarketInfoUc.xaml
    /// </summary>
    public partial class MarketInfoUc : UserControl
    {
        private static readonly DependencyProperty CurrentMarketProperty =
        DependencyProperty.Register("CurrentMarket", typeof(MarketModel), typeof(MarketInfoUc));
        public MarketModel CurrentMarket
        {


            get
            {
                return GetValue(CurrentMarketProperty) as MarketModel;



            }

            set
            {
                SetValue(CurrentMarketProperty, value);

            }


        }
        public MarketInfoUc()
        {
            InitializeComponent();
        }
    }
}
