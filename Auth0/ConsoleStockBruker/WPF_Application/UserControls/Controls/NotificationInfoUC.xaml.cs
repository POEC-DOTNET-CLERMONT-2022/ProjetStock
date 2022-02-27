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
    /// Logique d'interaction pour NotificationiNFOUC.xaml
    /// </summary>
    public partial class NotificationInfoUC : UserControl
    {
        private static readonly DependencyProperty CurrentNotifProperty =
         DependencyProperty.Register("CurrentNotif", typeof(NotificationModel), typeof(NotificationInfoUC));
        public NotificationModel CurrentNotif
        {


            get
            {
                return GetValue(CurrentNotifProperty) as NotificationModel;



            }

            set
            {
                SetValue(CurrentNotifProperty, value);

            }


        }


        public NotificationInfoUC()
        {
            InitializeComponent();
        }
    }
}
