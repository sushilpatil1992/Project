using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> GetCategory();
        Category GetCategoryByID(int categoryId);
        int InsertCategory(Category category);
        int DeleteCategory(int categoryrId);
        int UpdateCategory(Category category);
        void Save();
    }
}
