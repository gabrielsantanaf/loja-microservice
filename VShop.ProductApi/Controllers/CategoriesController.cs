using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;
using VShop.Web.Roles;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDTO = await _categoryService.GetCategories();

            if (categoriesDTO is null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);

            if (categoryDTO is null)
                return NotFound("Category not found");

            return Ok(categoryDTO);
        }

        [HttpGet("products")]
        public async Task<ActionResult<CategoryDTO>> GetCateriesProducts()
        {
            var categories = await _categoryService.GetCategoriesProducts();

            if (categories is null)
                return NotFound("Categories with products not found");

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return BadRequest("Invalid Data");

            await _categoryService.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
                return BadRequest();

            if (categoryDTO is null)
                return BadRequest();

            await _categoryService.UpdateCategory(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categotyDTO = await _categoryService.GetCategoryById(id);

            if (categotyDTO is null)
                return NotFound("Category not found");

            await _categoryService.RemoveCategory(id);

            return Ok(categotyDTO);
        } 
    }
}
