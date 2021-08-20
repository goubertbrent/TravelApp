using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models
{
    public class ItemLine
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
        public bool IsChecked { get; set; }
    }
}
