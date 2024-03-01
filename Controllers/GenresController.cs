using MangaStoreAPI.Models;
using MangaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IProjectService<Genres> _genresService;

        public GenresController(IProjectService<Genres> genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public ActionResult<List<Genres>> GetAllGenres()
        {
            List<Genres> genres = _genresService.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Genres> GetGenreById(string id)
        {
            Genres genre = _genresService.GetById(id);

            if (genre == null)
                return NotFound();

            return genre;
        }

        [HttpPost]
        public ActionResult<Genres> CreateGenre([FromBody] Genres genre)
        {
            _genresService.Insert(genre);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateGenre(string id, Genres genreToUp)
        {
            Genres genre = _genresService.GetById(id);

            if (genre == null)
                return NotFound();

            _genresService.Update(id, genreToUp);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteGenre(string id)
        {
            Genres genre = _genresService.GetById(id);

            if (genre == null)
                return NotFound();

            _genresService.Delete(id);

            return Ok();
        }
    }
}
