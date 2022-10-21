using CrudOperations.Business.Abstract;
using CrudOperations.Business.Concrete;
using CrudOperations.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudOperations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public List<Category> Get()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        public Category Create([FromBody]Category category)
        {
            return _categoryService.CreateCategory(category);
        }
        [HttpPut]
        public Category Update([FromBody] Category category)
        {
            return _categoryService.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
