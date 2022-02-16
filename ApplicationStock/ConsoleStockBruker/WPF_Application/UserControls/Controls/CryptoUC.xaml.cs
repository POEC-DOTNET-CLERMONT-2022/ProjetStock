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
    /// Interaction logic for CryptoUC.xaml
    /// </summary>
    public partial class CryptoUC : UserControl
    {
        private static readonly DependencyProperty CurrentCryptoProperty =
    DependencyProperty.Register("CurrentCrypto", typeof(CryptoModel), typeof(CryptoUC));
        public CryptoModel CurrentCrypto
        {
            get
            {
                return GetValue(CurrentCryptoProperty) as CryptoModel;
            }

            set
            {
                SetValue(CurrentCryptoProperty, value);
            }
        }
        public CryptoUC()
        {
            InitializeComponent();
        }
    }
}
