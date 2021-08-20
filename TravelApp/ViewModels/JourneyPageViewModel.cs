using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListFrontend.DTO;
using TravelListFrontend.Models;

namespace TravelListFrontend.ViewModels
{
    public class JourneyPageViewModel
    {
        #region Properties
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public ObservableCollection<Journey> Journeys { get; set; }
        #endregion

        #region Constructors
        public JourneyPageViewModel()
        {
            Journeys = new ObservableCollection<Journey>();
            LoadJourneysAsync();
        }
        #endregion

        #region Methods
        private async void LoadJourneysAsync()
        {
            HttpClient client = new HttpClient();
            string link = "http://localhost:65495/api/journey/user/" + localSettings.Values["user"].ToString();
            var json = await client.GetStringAsync(new Uri(link));
            var journeys = JsonConvert.DeserializeObject<IList<Journey>>(json);

            foreach(Journey journey in journeys)
            {
                Journeys.Add(journey);
            }
        }

        public async void PostJourney(JourneyDTO newJourney)
        {
            var journeyJson = JsonConvert.SerializeObject(newJourney);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:65495/api/journey", new StringContent(journeyJson, System.Text.Encoding.UTF8,"application/json"));
        }

        public async Task<IList<Category>> GetCategories(int journeyId)
        {
            HttpClient client = new HttpClient();
            string link = "http://localhost:65495/api/journey/" + journeyId + "/categories";
            var json = await client.GetStringAsync(new Uri(link));
            var categories = JsonConvert.DeserializeObject<IList<Category>>(json);
            return categories;
        }
        #endregion

    }
}
