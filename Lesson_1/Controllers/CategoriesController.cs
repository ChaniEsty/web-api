using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/<CategoriesController>
    [HttpGet]
    public async Task<ActionResult<List<Category>>>Get()
    {
            List<Category> categories = await _categoryService.GetCategories();
            return categories == null ? NoContent() : Ok(categories);

    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
            Category category = await _categoryService.GetCategoryById(id);
            return category == null ? NoContent() : Ok(category);
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<ActionResult<Category>> Post([FromBody] Category Newcategory)
    {
            Category category = await _categoryService.CreateCategory(Newcategory);
            return CreatedAtAction(nameof(Get), new {id=category.Id},category  );
    }
}
}
