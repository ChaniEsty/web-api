using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
        
    }
}