using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelApp.Util;
using TravelApp.ViewModels;
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

namespace TravelApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JourneyDetail : Page
    {
        private JourneyPageViewModel viewModel = new JourneyPageViewModel();
        public Journey currentJourney { get; set; }
        public IList<Category> Categories { get; set; }
        public JourneyDetail()
        {
            this.InitializeComponent();
            Categories = new List<Category>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            currentJourney = (Journey)e.Parameter;
            TxTHeader.Text = "Journey: " + currentJourney.Name;
            Categories = await viewModel.GetCategories(currentJourney.Id);
            ListItems.DataContext = new CollectionViewSource { Source = Categories };
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            JourneyParameters parameters = new JourneyParameters();
            parameters.JourneyId = currentJourney.Id;
            Category clickedCategory = (sender as TextBlock).DataContext as Category;
            parameters.Category = clickedCategory;
            this.Frame.Navigate(typeof(ItemPage), parameters);
        }
    }
}
