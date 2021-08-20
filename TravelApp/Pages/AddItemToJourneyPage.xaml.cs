using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelApp.DTO;
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
    public sealed partial class AddItemToJourneyPage : Page
    {
        private JourneyPageViewModel viewModel;
        public Journey currentJourney { get; set; }
        public AddItemToJourneyPage()
        {
            this.InitializeComponent();
            viewModel = new JourneyPageViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            currentJourney = (Journey)e.Parameter;
            TxTHeader.Text = "Journey: " + currentJourney.Name;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TxtDone.Visibility = Visibility.Collapsed;
            int amount = Int32.Parse(AmountItem.Text);
            ItemLineDTO itemLineDTO = new ItemLineDTO() {Amount = amount, ItemName = ItemCombo.SelectedValue.ToString()  };
            viewModel.AddItemLine(currentJourney.Id, itemLineDTO);
            AmountItem.Text = "";
            TxtDone.Visibility = Visibility.Visible;
        }
    }
}
