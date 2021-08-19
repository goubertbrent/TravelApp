using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.ViewModels
{
    public class NavigationViewModel
    {
        public List<String> menuIcons { get; set; }

        public NavigationViewModel()
        {
            menuIcons = new List<string>() { "Journeys", "Add Journey"};
        }

    }
}
