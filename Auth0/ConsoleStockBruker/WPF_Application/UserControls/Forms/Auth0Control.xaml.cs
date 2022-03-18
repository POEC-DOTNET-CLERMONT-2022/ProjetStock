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
using Auth0.OidcClient;
using WPF_Application.Utils;

namespace WPF_Application.UserControls.Forms
{
    /// <summary>
    /// Logique d'interaction pour Auth0Control.xaml
    /// </summary>
    public partial class Auth0Control : UserControl
    {
        
        private Auth0Client client { get; set; }
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public Auth0Control()
        {
            InitializeComponent();

        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;

            Auth0ClientOptions clientOptions = new Auth0ClientOptions
            {
                Domain = "dev-kiw3a5n6.eu.auth0.com",
                ClientId = "muriWtKTSx3HvU4CpqxlJRaFYzaefiHK"
            };
            client = new Auth0Client(clientOptions);
            clientOptions.PostLogoutRedirectUri = clientOptions.RedirectUri;

            var loginResult = await client.LoginAsync();

            if(loginResult.TokenResponse.HttpStatusCode ==  System.Net.HttpStatusCode.OK)
            {
                Navigator.NavigateTo(typeof(UserMainWindowsConnected));
            }
            else
            {

                Navigator.NavigateTo(typeof(LoginControle));
            }

        }
    }
}
