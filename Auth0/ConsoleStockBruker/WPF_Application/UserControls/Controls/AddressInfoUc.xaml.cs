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
    /// Logique d'interaction pour AddressInfoUc.xaml
    /// </summary>
    public partial class AddressInfoUc : UserControl
    {
        private static readonly DependencyProperty CurrentAddressProperty =
          DependencyProperty.Register("CurrentAddress", typeof(AddressModel), typeof(AddressInfoUc));
        public AddressModel CurrentAddress
        {


            get
            {
                return GetValue(CurrentAddressProperty) as AddressModel;



            }

            set
            {
                SetValue(CurrentAddressProperty, value);

            }


        }
        public AddressInfoUc()
        {
            InitializeComponent();
        }
    }
}
