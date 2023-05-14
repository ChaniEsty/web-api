using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    ICategoryService _categoryService;
     IMapper _mapper;
    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    // GET: api/<CategoriesController>
    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>>Get()
    {
            List<Category> categories = await _categoryService.GetCategories();
            List<CategoryDto> categoriesDto =_mapper.Map<List<Category>,List<CategoryDto>>(categories);
            return categories == null ? NoContent() : Ok(categoriesDto);

    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
            Category category = await _categoryService.GetCategoryById(id);
            CategoryDto categoryDto = _mapper.Map<Category,CategoryDto>(category);
            return category == null ? NoContent() : Ok(categoryDto);
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto NewcategoryDto)
    {
            Category Newcategory = _mapper.Map<CategoryDto, Category>(NewcategoryDto);
            Category category = await _categoryService.CreateCategory(Newcategory);
            CategoryDto categoryDto = _mapper.Map<Category, CategoryDto>(category);
            return CreatedAtAction(nameof(Get), new {id=categoryDto.Id},categoryDto);
    }
}
}
