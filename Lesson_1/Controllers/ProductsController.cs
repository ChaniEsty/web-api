using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        List<Product> products = await _productService.GetProducts();
        return products == null ? NoContent() : Ok(products);

    }
        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _productService.GetProductById(id);
            return product == null ? NoContent() : Ok(product);
        }
        // POST api/<CategoriesController>
        [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product newProduct)
    {
        Product product = await _productService.CreateProduct(newProduct);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
        
}
}
