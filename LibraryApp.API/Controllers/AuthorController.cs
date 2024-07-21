using LibraryApp.BLL.Services;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }

        [HttpGet]
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult AddAuthor([FromBody] Author author)
        {
            _authorService.AddAuthor(author);
            return CreatedAtRoute("DefaultApi", new { id = author.AuthorId }, author);
        }

        [HttpPut]
        public IHttpActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            var existingAuthor = _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            _authorService.UpdateAuthor(author);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAuthor(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            _authorService.DeleteAuthor(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
