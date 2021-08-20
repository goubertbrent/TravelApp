using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;

namespace TravelAppBackend.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DataInitializer(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async System.Threading.Tasks.Task InitializeData()
        {

            _context.Database.EnsureDeleted();
            if(_context.Database.EnsureCreated())
            {
                Customer user1 = new Customer() { Email = "brent@example.com" , Name= "Brent"};
                _context.Customers.Add(user1);
                await CreateUser(user1.Email, "P@ssword11111!");
                _context.SaveChanges();

                Category badkamer = new Category() {Name="badkamer", User = user1 };
                Category slaapkamer = new Category() { Name = "slaapkamer", User = user1 };
                _context.Categories.Add(badkamer);
                _context.Categories.Add(slaapkamer);
                _context.SaveChanges();

                Item item1 = new Item() { Name = "tandenborstel", Category = badkamer };
                Item item2 = new Item() { Name = "tandpasta", Category = badkamer };
                Item item3 = new Item() { Name = "kussen", Category = slaapkamer };
                _context.Items.Add(item1);
                _context.Items.Add(item2);
                _context.Items.Add(item3);
                _context.SaveChanges();

                Models.Task task1 = new Models.Task() { Description = "Visum bestellen online" };
                Models.Task task2 = new Models.Task() { Description = "Batterij gsm opladen" };

                ItemLine itemline1 = new ItemLine() { Item = item1, Amount = 2, IsChecked=false };
                ItemLine itemline2 = new ItemLine() { Item = item2, Amount = 1, IsChecked=true };
                ItemLine itemline3 = new ItemLine() { Item = item3, Amount = 3, IsChecked =false };

                Journey journey = new Journey() {Name = "Frankrijk caravan",Start = DateTime.Now.AddDays(15), User = user1 };
                journey.addItem(itemline1);
                journey.addItem(itemline2);
                journey.addItem(itemline3);
                journey.addTask(task1);
                journey.addTask(task2);
                _context.Journeys.Add(journey);


                _context.SaveChanges();
            }
        }
        private async System.Threading.Tasks.Task CreateUser(string email, string password)
        {
            var user = new IdentityUser {  Email = email, UserName = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
