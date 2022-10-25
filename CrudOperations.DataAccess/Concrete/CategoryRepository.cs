using CrudOperations.DataAccess.Abstract;
using CrudOperations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                // soft delete yapılıp isDeleted flag'i true yapılmalı
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

        public async Task<bool> IsNameExistAsync(string name)
        {
            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                var res = await crudOperationsDbContext.Categories.AnyAsync(x => x.Name == name);
                if (res)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> HasRelatedCategoryAsync(int id)
        {
            using (var crudOperationsDbContext = new CrudOperationsDbContext())
            {
                var res = await crudOperationsDbContext.Categories.AnyAsync(x => x.ParentId == id);
                if (res)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
