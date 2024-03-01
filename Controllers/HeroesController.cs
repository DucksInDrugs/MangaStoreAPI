using MangaStoreAPI.Models;
using MangaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IProjectService<Heroes> _heroesService;

        public HeroesController(IProjectService<Heroes> heroesService)
        {
            _heroesService = heroesService;
        }

        [HttpGet]
        public ActionResult<List<Heroes>> GetAllHeroes()
        {
            List<Heroes> heroes = _heroesService.GetAll();
            return Ok(heroes);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Heroes> GetHeroById(string id)
        {
            Heroes hero = _heroesService.GetById(id);

            if (hero == null)
                return NotFound();

            return hero;
        }

        [HttpPost]
        public ActionResult<Heroes> CreateHero([FromBody] Heroes hero)
        {
            _heroesService.Insert(hero);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateHero(string id, Heroes heroToUp)
        {
            Heroes hero = _heroesService.GetById(id);

            if (hero == null)
                return NotFound();

            _heroesService.Update(id, heroToUp);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteHero(string id)
        {
            Heroes hero = _heroesService.GetById(id);

            if (hero == null)
                return NotFound();

            _heroesService.Delete(id);

            return Ok();
        }
    }
}
