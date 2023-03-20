using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetCategories();
    }
}