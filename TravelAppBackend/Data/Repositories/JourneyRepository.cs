using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class JourneyRepository : IJourneyRepository

    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Journey> _journeys;

        public JourneyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _journeys = dbContext.Journeys;
        }

        public void Add(Journey journey)
        {
            _journeys.Add(journey);
        }

        public void changeChecked(int journeyId, int itemLineId, bool isChecked)
        {
            Journey journey = GetBy(journeyId);
            ItemLine item = journey.Items.Where(item => item.Id == itemLineId).SingleOrDefault();
            item.IsChecked = isChecked;

        }

        public void Delete(Journey journey)
        {
            _journeys.Remove(journey);
        }

        public IEnumerable<Journey> GetAll()
        {
            return _journeys.ToList();
        }

        public Journey GetBy(int journeyId)
        {
            return _journeys.Include(j => j.User).Include(j => j.Items).ThenInclude(il => il.Item).ThenInclude(i => i.Category).Include(j => j.Tasks).SingleOrDefault(j => j.Id == journeyId);
        }

        public IEnumerable<Journey> GetByUser(string email)
        {
            return _journeys.Include(j => j.User).Where(j => j.User.Email == email).ToList();
        }

        public IEnumerable<Category> getCategories(int journeyId)
        {
            Journey journey = GetBy(journeyId);
            return journey.Items.Select(item => item.Item.Category).Distinct().ToList();
        }

        public IEnumerable<ItemLine> getItems(int journeyId, int categoryId)
        {
            Journey journey = GetBy(journeyId);
            return journey.Items.Where(item => item.Item.Category.Id == categoryId).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool TryGetJourney(int id, out Journey journey)
        {
            journey = _dbContext.Journeys.Include(j => j.Items).FirstOrDefault(j => j.Id == id);
            return journey != null;
        }
    }
}
