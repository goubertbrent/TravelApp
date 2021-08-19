using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using TravelApp;
using TravelApp.DTO;
using TravelApp.Pages;
using TravelApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListFrontend.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public LoginViewModel viewModel { get; set; }
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public RegisterPage()
        {
            this.InitializeComponent();
            viewModel = new LoginViewModel();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(checkForms())
            {
                RegisterDTO registerData = new RegisterDTO() { Email = Email.Text, Name = Name.Text, Password = Password.Password };
                viewModel.Register(registerData);
                localSettings.Values["user"] = Email.Text;
                this.Frame.Navigate(typeof(NavigationPage));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
                this.Frame.Navigate(typeof(MainPage));
        }

        private bool checkForms()
        {
            bool isComplete = true;
            if(Name.Text == "")
            {
                ErrorName.Visibility = Visibility.Visible;
                isComplete = false;
            }
            if (string.IsNullOrWhiteSpace(Email.Text) || !Regex.IsMatch(Email.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                ErrorEmail.Visibility = Visibility.Visible;
                isComplete = false;
            }
            if(Password.Password.Length < 8 )
            {
                ErrorPassword.Visibility = Visibility.Visible;
                isComplete = false;
            }
            if(Password.Password != PassConf.Password)
            {
                ErrorConf.Visibility = Visibility.Visible;
                isComplete = false;
            }
            return isComplete;
        }
    }
}
