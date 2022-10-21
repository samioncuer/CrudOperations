using CrudOperations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories ();
        Category GetCategoryById (int id);
        Category CreateCategory (Category category);
        Category UpdateCategory (Category category);
        void DeleteCategory (int id);
    }
}
