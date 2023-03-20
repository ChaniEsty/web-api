using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);

        }
        public async Task<Category> CreateCategory(Category category)
        {
            return await _categoryRepository.CreateCategory(category);

        }
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();

        }
    }
}
