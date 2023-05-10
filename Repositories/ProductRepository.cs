using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        EstyWebApiContext _estyWebApiContext;

        public ProductRepository(EstyWebApiContext estyWebApiContext)
        {
            _estyWebApiContext = estyWebApiContext;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _estyWebApiContext.Products.Where(product => 
                                                                      (categories.Length==0  ? true : categories.Contains(product.CategoryId))
                                                                   && (productName == null ? true :product.Name.Contains(productName))
                                                                   && (minPrice == null ? true : product.Price >= minPrice)
                                                                   && (maxPrice == null ? true : product.Price <= maxPrice )). Include(product => product.Category).ToListAsync();

        }
        public async Task<Product> GetProductById(int id)
        {
            return await _estyWebApiContext.Products.FindAsync(id);
            // return await _estyWebApiContext.Products.Include(product => product.Category).FindAsync(id);
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _estyWebApiContext.Products.AddAsync(product);
            await _estyWebApiContext.SaveChangesAsync();
            return product;

        }
    }
}

