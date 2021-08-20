using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelApp.Util;
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
    public sealed partial class ItemPage : Page
    {
        public Category currentCategory { get; set; }
        public IList<ItemLine> Items { get; set; }
        public int JourneyId { get; set; }
        public JourneyPageViewModel viewModel { get; set; }
        public ItemPage()
        {
            this.InitializeComponent();
            Items = new List<ItemLine>();
            viewModel = new JourneyPageViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            JourneyParameters parameters = (JourneyParameters)e.Parameter;
            currentCategory = parameters.Category;
            JourneyId = parameters.JourneyId;
            TxTHeader.Text = "Category: " + currentCategory.Name;
            Items = await viewModel.GetItems(JourneyId, currentCategory.Id);
            ListItems.DataContext = new CollectionViewSource { Source = Items };
        }

        private void CheckBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("----------Tap------------");
            CheckBox checkbox = (sender as CheckBox);
            ItemLine clickedItem = checkbox.DataContext as ItemLine;
            bool isChecked = (bool)checkbox.IsChecked;
            
            viewModel.EditIsChecked(JourneyId, clickedItem.Id, isChecked);
        }
    }
}
