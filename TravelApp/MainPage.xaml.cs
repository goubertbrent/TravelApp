using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TravelApp.DTO;
using TravelApp.Pages;
using TravelApp.ViewModels;
using TravelListFrontend.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TravelApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public LoginViewModel viewModel { get; set; }
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new LoginViewModel();
        }
       
        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            LoginDTO login = new LoginDTO() { Email = TxtUsername.Text, Password = TxtPassword.Password };
            bool isLoggedIn = await viewModel.Login(login);
            if (isLoggedIn)
            {
                localSettings.Values["user"] = TxtUsername.Text;
                this.Frame.Navigate(typeof(NavigationPage));
            }
            else
            {
                ErrorText.Visibility = Visibility.Visible;
                TxtUsername.Text = "";
                TxtPassword.Password = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(RegisterPage));
            
        }
    }
}
