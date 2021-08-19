using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models.Repositories
{
    public interface IJourneyRepository
    {
        IEnumerable<Journey> GetAll();
        IEnumerable<Journey> GetByUser(string email);
        Journey GetBy(int journeyId);
        void Add(Journey journey);
        void Delete(Journey journey);
        bool TryGetJourney(int id, out Journey journey);
        void SaveChanges();

    }
}
