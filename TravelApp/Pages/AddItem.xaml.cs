using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelApp.DTO;
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

namespace TravelApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddItem : Page
    {
        public CategoryViewModel viewModel { get; set; }
        public List<String> TestList { get; set; } = new List<string> { "slaapkamer", "badkamer" };
        public AddItem()
        {
            this.InitializeComponent();
            viewModel = new CategoryViewModel();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TxtDone.Visibility = Visibility.Collapsed;
            ItemDTO item = new ItemDTO() { Name = NameItem.Text, CategoryName = CategoryCombo.SelectedValue.ToString() };
            viewModel.createItem(item);
            TxtDone.Visibility = Visibility.Visible;
        }

        private void ListBox2_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
