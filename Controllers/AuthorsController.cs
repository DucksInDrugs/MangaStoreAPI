using MangaStoreAPI.Models;
using MangaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IProjectService<Authors> _authorsService;

        public AuthorsController(IProjectService<Authors> authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public ActionResult<List<Authors>> GetAllAuthors()
        {
            List<Authors> authors = _authorsService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Authors> GetAuthorById(string id)
        {
            Authors authors = _authorsService.GetById(id);

            if (authors == null)
                return NotFound();

            return authors;
        }

        [HttpPost]
        public ActionResult<Authors> CreateAuthor([FromBody] Authors author)
        {
            _authorsService.Insert(author);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateAuthor(string id, Authors authorToUp)
        {
            Authors author = _authorsService.GetById(id);

            if (author == null)
                return NotFound();

            _authorsService.Update(id, authorToUp);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteAuthor(string id)
        {
            Authors author = _authorsService.GetById(id);

            if (author == null)
                return NotFound();

            _authorsService.Delete(id);

            return Ok();
        }
    }
}
