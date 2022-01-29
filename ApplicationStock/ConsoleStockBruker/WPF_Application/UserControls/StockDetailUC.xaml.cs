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
    /// Logique d'interaction pour StockDetailUC.xaml
    /// </summary>
    public partial class StockDetailUC : Window
    {
        private static DependencyProperty CurrentStockProperty =
             DependencyProperty.Register("CurrentStock", typeof(StockModel), typeof(StockDetailUC));

        public StockDetailUC()
        {
            InitializeComponent();
        }

        private StockModel currentModel;

        public StockModel CurrentModel
        {
            get { return GetValue(CurrentStockProperty) as StockModel; }
            set
            {
                if(currentModel != value)
                {
                    SetValue(CurrentStockProperty, value);
                }
            }

        }
    }
}
