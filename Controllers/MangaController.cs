using MangaStoreAPI.Models;
using MangaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IProjectService<Manga> _mangaService;

        public MangaController(IProjectService<Manga> mangaService)
        {
            _mangaService = mangaService;
        }

        [HttpGet]
        public ActionResult<List<Manga>> GetAllManga()
        {
            List<Manga> manga = _mangaService.GetAll();
            return Ok(manga);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Manga> GetMangaById(string id)
        {
            Manga manga = _mangaService.GetById(id);

            if (manga == null)
                return NotFound();

            return manga;
        }

        [HttpPost]
        public ActionResult<Manga> CreateManga([FromBody] Manga manga)
        {
            _mangaService.Insert(manga);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateManga(string id, Manga mangaToUp)
        {
            Manga manga = _mangaService.GetById(id);

            if (manga == null)
                return NotFound();

            _mangaService.Update(id, mangaToUp);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteManga(string id)
        {
            Manga manga = _mangaService.GetById(id);

            if (manga == null)
                return NotFound();

            _mangaService.Delete(id);

            return Ok();
        }
    }
}
