using ProjectStockLibrary;
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
    /// Logique d'interaction pour OrderInfoControl.xaml
    /// </summary>
    public partial class OrderInfoControl : UserControl
    {
        private static readonly DependencyProperty CurrentOrderProperty =
          DependencyProperty.Register("CurrentOrder", typeof(OrderModel), typeof(OrderInfoControl));
        public OrderModel CurrentOrder
        {


            get
            {
                return GetValue(CurrentOrderProperty) as OrderModel;



            }

            set
            {
                SetValue(CurrentOrderProperty, value);

            }


        }

        public OrderInfoControl()
        {
            InitializeComponent();
        }
    }
}
