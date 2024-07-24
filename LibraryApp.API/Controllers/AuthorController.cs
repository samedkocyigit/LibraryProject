using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }
        [HttpGet]
        [Route("api/author/{authorId}/books")]
        public IHttpActionResult GetBooksByAuthor(int authorId) 
        {
            var books= _authorService.GetBooksByAuthor(authorId);
            if (books==null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("api/author/name/{name}")]
        public IHttpActionResult GetAuthorByName(string name)
        {
            var author = _authorService.GetAuthorByName(name);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
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
