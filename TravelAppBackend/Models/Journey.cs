using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public List<ItemLine> Items { get; set; }
        public List<Task> Tasks { get; set; }
        public Customer User { get; set; }

        #region Constructors
        public Journey()
        {
            Items = new List<ItemLine>();
            Tasks = new List<Task>();
        }

        #endregion



        #region Methods
        public void addItem(ItemLine item) => Items.Add(item);
        public void addTask(Task task) => Tasks.Add(task);
        public ItemLine GetItem(int id) => Items.SingleOrDefault(j => j.Id == id);
        #endregion
    }
}
