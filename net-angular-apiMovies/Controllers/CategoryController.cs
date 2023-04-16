using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_angular_apiMovies.Models.Domain;
using net_angular_apiMovies.Models.DTOs;
using net_angular_apiMovies.Repositories.Abstract;

namespace net_angular_apiMovies.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _categoryRepository.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound(); // Ritorna una risposta 404 se la categoria non viene trovata
            }

            return Ok(category);
        }


        [HttpPost]
        public IActionResult AddUpdate(Category category)
        {
            var result = _categoryRepository.AddUpdate(category);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                Message = result ? "Categoria aggiunta" : "Non è possibile aggiungere la categoria"
            };
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _categoryRepository.Delete(id);
            return Ok(data);
        }
    }
}
