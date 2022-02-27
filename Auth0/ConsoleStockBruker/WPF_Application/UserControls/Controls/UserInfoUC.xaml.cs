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
    /// Logique d'interaction pour UserInfoUC.xaml
    /// </summary>
    public partial class UserInfoUC : UserControl
    {
        private static readonly DependencyProperty CurrentUserProperty =
      DependencyProperty.Register("CurrentUtilisateur", typeof(UserModel), typeof(UserInfoUC));
        public UserModel CurrentUtilisateur
        {


            get
            {
                return GetValue(CurrentUserProperty) as UserModel;



            }

            set
            {
                SetValue(CurrentUserProperty, value);

            }


        }
        public UserInfoUC()
        {
            InitializeComponent();
        }
    }
}
