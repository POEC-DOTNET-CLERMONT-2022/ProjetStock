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

namespace WPF_Application.UserControls.Controls
{
    /// <summary>
    /// Logique d'interaction pour ButtonBackUserControl.xaml
    /// </summary>
    public partial class ButtonBackUserControl : UserControl
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public ButtonBackUserControl()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Navigator.Back();

        }

    }
}
