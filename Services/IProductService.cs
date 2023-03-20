using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
    }
}