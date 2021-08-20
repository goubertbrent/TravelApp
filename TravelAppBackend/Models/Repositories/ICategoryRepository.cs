using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models.Repositories
{
    public interface ICategoryRepository
    {
        Category getById(int id);
        void SaveChanges();
        void Add(Category category);
        bool findName(string name);
        IEnumerable<Category> GetAll(string email);
    }
}
