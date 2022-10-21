using CrudOperations.Business.Abstract;
using CrudOperations.DataAccess.Abstract;
using CrudOperations.DataAccess.Concrete;
using CrudOperations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public Category CreateCategory(Category category)
        {
            //try catch log
            return _categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            //try catch log
            _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
            //try catch log
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            //try catch log
            return _categoryRepository.GetCategoryById(id);
        }

        public Category UpdateCategory(Category category)
        {
            //try catch log
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
