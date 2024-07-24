using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LibraryApp.API.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet]
        public IHttpActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpGet]
        [Route("api/book/floor/{floorId}")]
        public IHttpActionResult GetBooksByFloor(int floorId)
        {
            var books = _bookService.GetBooksByFloor(floorId);
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpGet]
        [Route("api/book/category/{categoryId}")]
        public IHttpActionResult GetBooksByCategory(int categoryId)
        {
            var books = _bookService.GetBooksByCategory(categoryId);
            if (books==null || !books.Any())
            {
                return NotFound();

            }
            return Ok(books);
        }
        [HttpGet]
        [Route("api/book/title/{title}")]
        public IHttpActionResult GetBookByTitle(string title)
        {
            var book = _bookService.GetBookByTitle(title);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _bookService.UpdateBook(existingBook);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
