using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelApp.Pages;
using TravelListFrontend.Models;
using TravelListFrontend.ViewModels;
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
    public sealed partial class JourneyPage : Page
    {
        #region Properties
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public JourneyPageViewModel viewModel { get; set; }
        #endregion
        public JourneyPage()
        {
            this.InitializeComponent();
            viewModel = new JourneyPageViewModel();
            JourneyList.DataContext = new CollectionViewSource { Source = viewModel.Journeys };
            TxtWelcomeUser.Text = "Welcome " + localSettings.Values["user"].ToString() + "!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Journey clickedJourney = (sender as Button).DataContext as Journey;
            this.Frame.Navigate(typeof(JourneyDetail), clickedJourney);
        }
    }
}
