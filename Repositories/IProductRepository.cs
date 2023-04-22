using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
    }
}