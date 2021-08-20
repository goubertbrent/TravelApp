using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DTO;

namespace TravelApp.ViewModels
{
    public class CategoryViewModel
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public async void CreateCategory(string text)
        {
            CategoryDTO category = new CategoryDTO() {Name = text, Email= localSettings.Values["user"].ToString() };
            var categoryJson = JsonConvert.SerializeObject(category);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/category", new StringContent(categoryJson, System.Text.Encoding.UTF8, "application/json"));
        }
    }
}
