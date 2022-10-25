using CrudOperations.Business.Abstract;
using CrudOperations.Business.Concrete;
using CrudOperations.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<Category> Create([FromBody]Category category)
        {
            return await _categoryService.CreateCategory(category);
        }
        [HttpPut]
        public async Task<Category> Update([FromBody] Category category)
        {
            return await _categoryService.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }
    }
}
