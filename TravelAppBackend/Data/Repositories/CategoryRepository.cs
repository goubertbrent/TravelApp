using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Category> _categories;
        #endregion
        #region Constructors
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _categories = dbContext.Categories;
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public bool findName(string name)
        {
            Category category = _categories.SingleOrDefault(i => i.Name == name);
            return category != null;
        }

        public IEnumerable<Category> GetAll(string email)
        {
            return _categories.Include(cat => cat.User).Where(cat => cat.User.Email == email);
        }
        #endregion
        #region Methods
        public Category getById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion


    }
}
