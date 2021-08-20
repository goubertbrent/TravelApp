using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationPage : Page
    {
        private String addJourneyText = "Add Journey";
        public NavigationViewModel viewModel { get; set; }
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public NavigationPage()
        {
            this.InitializeComponent();
            SplitViewFrame.Navigate(typeof(JourneyPage));
            viewModel = new NavigationViewModel();
            Menu.DataContext = new CollectionViewSource { Source = viewModel.menuIcons };
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = ((Button)sender).Content.ToString();
            if(buttonText == addJourneyText)
            {
                SplitViewFrame.Navigate(typeof(AddJourneyPage));
            }
            else
            {
                SplitViewFrame.Navigate(typeof(JourneyPage));
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["user"] = "";
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (SplitViewFrame.CanGoBack)
            {
                SplitViewFrame.GoBack();
                
            }
        }
    }
}
