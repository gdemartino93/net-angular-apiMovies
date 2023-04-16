using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_angular_apiMovies.Models.Domain;
using net_angular_apiMovies.Models.DTOs;
using net_angular_apiMovies.Repositories.Abstract;

namespace net_angular_apiMovies.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _movieRepository.GetAll();
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var data = _movieRepository.GetById(id);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddUpdate(Movie movie)
        {
            var result = _movieRepository.AddUpdate(movie);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                Message = result ? "Film aggiunto correttamente" : "C'è stato un errore"
            };
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _movieRepository.Delete(id);
            var status = new Status
            {
                StatusCode = data ? 1 : 0,
                Message = data ? "Film eliminato" : "C'è stato un errore"
            };
            return Ok(data);
        }
    }
}
