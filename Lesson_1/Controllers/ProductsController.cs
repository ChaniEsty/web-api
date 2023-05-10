using AutoMapper;
using DTO;
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
    IMapper _mapper;
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> Get([FromQuery]int?[] categories, [FromQuery] string? productName, [FromQuery] int? minPrice, [FromQuery] int? maxPrice)
    {
            List<Product> products = await _productService.GetProducts(categories,  productName, minPrice,maxPrice);
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return products == null ? NoContent() : Ok(productsDto);

    }
        // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        Product product = await _productService.GetProductById(id);
        ProductDto productDto = _mapper.Map<Product,ProductDto>(product);
        return product == null ? NoContent() : Ok(productDto);
    }
    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto newProductDto)
    {
        Product newProduct = _mapper.Map<ProductDto, Product>(newProductDto);
        Product product = await _productService.CreateProduct(newProduct);
        ProductDto productDto = _mapper.Map<Product, ProductDto>(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, productDto);
    }
        
}
}
