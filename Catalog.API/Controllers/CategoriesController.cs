using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _uof;

        public CategoriesController(ICategoryService categoryService, IUnitOfWork uof)
        {
            _categoryService = categoryService;
            _uof = uof;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category is null)
            {
                return NotFound("category not found");
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO categoryDto)
        {
            var newCategory = await _categoryService.Create(categoryDto);
            if (newCategory is null)
            {
                return BadRequest();
            }
            return new CreatedAtRouteResult("GetById",
            new { id = newCategory.Id }, newCategory);
        }
        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Put(CategoryDTO categoryDto)
        {
            var upCategory = await _categoryService.Update(categoryDto);
            if (upCategory is null)
            {
                return BadRequest();
            }
            return Ok(upCategory);
        }
        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category is null)
            {
                return NotFound("invalid data");
            }
            var deletedCategory = await _categoryService.Delete(id);
            return Ok(deletedCategory);
        }
    }
}
