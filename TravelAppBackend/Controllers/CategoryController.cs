using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.DTO;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public CategoryController( ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{email}")]
        public IEnumerable<Category> GetCategories(string email)
        {
            return _categoryRepository.GetAll(email);
        }


        [HttpPost]
        public IActionResult PostCategory(CategoryDTO categoryDTO)
        {
            if (_categoryRepository.findName(categoryDTO.Name))
            {
                return BadRequest();
            }
            Category category = new Category();
            category.Name = categoryDTO.Name;
            Customer user = _userRepository.GetBy(categoryDTO.Email);
            category.User = user;
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            return Ok();
        }
    }
}
