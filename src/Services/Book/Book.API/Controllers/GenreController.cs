using Book.API.Model;
using Book.API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenreList()
        {
            var bookImages = await _genreRepository.GetGenreList();
            return Ok(bookImages);
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre(Genre genre)
        {
            var flag = await _genreRepository.AddGenre(genre);
            return flag ? Ok("Genre added successfully.") : BadRequest("Unable to add genre.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGenre(Genre genre)
        {
            var flag = await _genreRepository.UpdateGenre(genre);
            return flag ? Ok("Genre updated successfully.") : BadRequest("Unable to update genre.");
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> DeleteGenre(string id)
        {
            var flag = await _genreRepository.DeleteGenre(id);
            return flag ? Ok("Genre deleted successfully.") : BadRequest("Unable to delete genre.");
        }
    }
}
