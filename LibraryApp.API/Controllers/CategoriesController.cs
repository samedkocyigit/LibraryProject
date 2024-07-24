using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult AddCategory([FromBody] Category category)
        {
            _categoryService.AddCategory(category);
            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryService.UpdateCategory(category);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.DeleteCategory(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
