using CrudOperations.DataAccess.Abstract;
using CrudOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudOperations.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category CreateCategory(Category category)
        {

            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                crudOperationsDbContext.Categories.Add(category);
                crudOperationsDbContext.SaveChanges();
                return category;
            }
        }

        public void DeleteCategory(int id)
        {

            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                var categoryToBeDeleted = GetCategoryById(id);
                crudOperationsDbContext.Categories.Remove(categoryToBeDeleted);
                crudOperationsDbContext.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {

            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                return crudOperationsDbContext.Categories.ToList();
            }

        }

        public Category GetCategoryById(int id)
        {

            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                return crudOperationsDbContext.Categories.Find(id);
            }

        }

        public Category UpdateCategory(Category category)
        {

            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                crudOperationsDbContext.Categories.Update(category);
                crudOperationsDbContext.SaveChanges();
                return category;
            }
        }

    }
}
