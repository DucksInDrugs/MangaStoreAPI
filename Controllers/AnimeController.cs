using MangaStoreAPI.Models;
using MangaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IProjectService<Anime> _animeService;

        public AnimeController(IProjectService<Anime> animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public ActionResult<List<Anime>> GetAllAnime()
        {
            List<Anime> anime = _animeService.GetAll();
            return Ok(anime);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Anime> GetAnimeById(string id)
        {
            Anime anime = _animeService.GetById(id);

            if (anime == null)
                return NotFound();

            return anime;
        }

        [HttpPost]
        public ActionResult<Anime> CreateAnime([FromBody] Anime anime)
        {
            _animeService.Insert(anime);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateAnime(string id, Anime animeToUp)
        {
            Anime anime = _animeService.GetById(id);

            if (anime == null)
                return NotFound();

            _animeService.Update(id, animeToUp);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteAnime(string id)
        {
            Anime anime = _animeService.GetById(id);

            if (anime == null)
                return NotFound();

            _animeService.Delete(id);

            return Ok();
        }
    }
}
