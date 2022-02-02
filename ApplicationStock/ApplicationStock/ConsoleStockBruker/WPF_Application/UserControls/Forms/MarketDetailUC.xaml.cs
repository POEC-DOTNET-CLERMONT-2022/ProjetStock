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
using System.Windows.Shapes;

namespace WPF_Application.UserControls
{
    /// <summary>
    /// Logique d'interaction pour MarketDetailUC.xaml
    /// </summary>
    public partial class MarketDetailUC : Window
    {


        private static readonly DependencyProperty CurrentMarketProperty =
            DependencyProperty.Register("CurrentMarket", typeof(MarketModel), typeof(MarketDetailUC));


        private MarketModel currentModel;
        
        public MarketModel CurrentMarket
        {
            get { return GetValue(CurrentMarketProperty) as MarketModel; }
            set
            {
                if(CurrentMarket != value)
                {
                    SetValue(CurrentMarketProperty, value);
                }
            }
        }
            
            
        public MarketDetailUC()
        {
            InitializeComponent();

        }


        
    }
}
