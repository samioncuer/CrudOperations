using CrudOperations.Business.Abstract;
using CrudOperations.DataAccess.Abstract;
using CrudOperations.DataAccess.Concrete;
using CrudOperations.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CrudOperations.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                var nameExist = await _categoryRepository.IsNameExistAsync(category.Name);
                if (String.IsNullOrEmpty(category.Name)) // fluent validation kullanılması daha sağlıklı olur
                {
                    throw new Exception("boş isimli kategori oluşturulamaz");
                }
                if (nameExist)
                {
                    throw new Exception("bu isimde kategori zaten var");
                }
                return _categoryRepository.CreateCategory(category);
            }catch(Exception ex){
                throw new Exception(ex.Message); // bir yerlere loglanmalı
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var relCat = await _categoryRepository.HasRelatedCategoryAsync(id);
                //aynı kontrol kategoriye bağlı ürünler için de yapılmalı 
                if (relCat)
                {
                    throw new Exception("bu kategoriye bağlı alt kategoriler olduğu için silme işlemi yapılamaz");
                }
                _categoryRepository.DeleteCategory(id);
                return true;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                var nameExist = await _categoryRepository.IsNameExistAsync(category.Name);
                if (String.IsNullOrEmpty(category.Name)) // fluent validation kullanılması daha sağlıklı olur
                {
                    throw new Exception("boş isimli kategori oluşturulamaz");
                }
                if (nameExist)
                {
                    throw new Exception("bu isimde kategori zaten var");
                }
                return _categoryRepository.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // bir yerlere loglanmalı
            }
        }
    }
}
