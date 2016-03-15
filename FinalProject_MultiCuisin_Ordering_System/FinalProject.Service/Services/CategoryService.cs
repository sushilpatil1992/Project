using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public IList<Category> GetCategory()
        {
            return _CategoryRepository.GetCategory();
        }

        public Category GetCategoryByID(int categoryId)
        {
            return _CategoryRepository.GetCategoryById(categoryId);
        }

        public int InsertCategory(Category category)
        {
            int status = _CategoryRepository.InsertCategory(category);
            return status;
        }

        public int DeleteCategory(int categoryId)
        {
            int status = _CategoryRepository.DeleteCategory(categoryId);
            return status;
        }

        public int UpdateCategory(Category category)
        {
            int status = _CategoryRepository.UpdateCategory(category);
            return status;
        }

        public void Save()
        {
            _CategoryRepository.Save();
        }
    }
    
}
