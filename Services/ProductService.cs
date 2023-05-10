using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);

        }
        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);

        }
        public async Task<List<Product>> GetProducts(int?[] categories, string? productName, int? minPrice, int? maxPrice)
        {
            return await _productRepository.GetProducts( categories,productName,  minPrice,maxPrice);

        }
    }
}

