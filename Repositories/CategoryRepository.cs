using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        EstyWebApiContext _estyWebApiContext;

        public CategoryRepository(EstyWebApiContext estyWebApiContext)
        {
            _estyWebApiContext = estyWebApiContext;
        }
        public async Task<List<Category>>GetCategories()
        {
            return await _estyWebApiContext.Categories.ToListAsync();

        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _estyWebApiContext.Categories.FindAsync(id);

        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _estyWebApiContext.Categories.AddAsync(category);
            await _estyWebApiContext.SaveChangesAsync();
            return category;

        }
    }
}
