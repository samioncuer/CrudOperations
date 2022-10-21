﻿using CrudOperations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
