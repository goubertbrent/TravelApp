using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Customer> _users;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _users = dbContext.Customers;
        }

        public void Add(Customer customer)
        {
            _users.Add(customer);
        }

        public Customer GetBy(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
