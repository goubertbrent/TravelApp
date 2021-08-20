using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DTO;
using TravelListFrontend.Models;

namespace TravelApp.ViewModels
{
    public class CategoryViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public IEnumerable<String> CategoryNames { get; set; }
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>();
            GetCategories();
        }
        
        public async void CreateCategory(string text)
        {
            CategoryDTO category = new CategoryDTO() {Name = text, Email= localSettings.Values["user"].ToString() };
            var categoryJson = JsonConvert.SerializeObject(category);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/category", new StringContent(categoryJson, System.Text.Encoding.UTF8, "application/json"));
        }

        private async void GetCategories()
        {
            HttpClient client = new HttpClient();
            string link = "http://localhost:65495/api/category/" + localSettings.Values["user"].ToString();
            var json = await client.GetStringAsync(new Uri(link));
            var categories = JsonConvert.DeserializeObject<IList<Category>>(json);

            foreach (Category category in categories)
            {
                Categories.Add(category);
            }
            CategoryNames = Categories.Select(cat => cat.Name);

            foreach (var name in CategoryNames)
            {
                Debug.WriteLine(name);
            }
        }

        public async void createItem(ItemDTO item)
        {
            
            var itemJson = JsonConvert.SerializeObject(item);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/item", new StringContent(itemJson, System.Text.Encoding.UTF8, "application/json"));
        }
    }
}
