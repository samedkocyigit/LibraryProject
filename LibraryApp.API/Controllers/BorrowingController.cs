using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class BorrowingController : ApiController
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public IEnumerable<Borrowing> GetAllBorrowings()
        {
            return _borrowingService.GetAllBorrowings();
        }

        [HttpPost]
        [Route("api/borrowing/borrow")]
        public IHttpActionResult BorrowBook([FromBody] BorrowBookModel model)
        {
            _borrowingService.BorrowBook(model.MemberId,model.BookId);
            return Ok("Book borrowed Successfully");
        }

        [HttpPost]
        [Route("api/borrowing/return")]
        public IHttpActionResult ReturnBook([FromBody] ReturnBookModel model)
        {
            _borrowingService.ReturnBook(model.MemberId, model.BookId);
            return Ok("Book returned Successfully");
        }

        [HttpGet]
        [Route("member/{memberId}")]
        public IHttpActionResult GetBorrowingsByMember(int memberId)
        {
            var borrowings = _borrowingService.GetBorrowingsByMember(memberId);
            return Ok(borrowings);
        }

        [HttpGet]
        [Route("book/{bookId}")]
        public IHttpActionResult GetBorrowingsByBook(int bookId)
        {
            var borrowings = _borrowingService.GetBorrowingsByBook(bookId);
            return Ok(borrowings);
        }

        [HttpGet]
        public IHttpActionResult GetBorrowingById(int id)
        {
            var borrowing = _borrowingService.GetBorrowingById(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return Ok(borrowing);
        }

        [HttpPost]
        public IHttpActionResult AddBorrowing([FromBody] Borrowing borrowing)
        {
            _borrowingService.AddBorrowing(borrowing);
            return CreatedAtRoute("DefaultApi", new { id = borrowing.BorrowingId }, borrowing);
        }

        [HttpPut]
        public IHttpActionResult UpdateBorrowing(int id, [FromBody] Borrowing borrowing)
        {
            if (id != borrowing.BorrowingId)
            {
                return BadRequest();
            }

            var existingBorrowing = _borrowingService.GetBorrowingById(id);
            if (existingBorrowing == null)
            {
                return NotFound();
            }
            _borrowingService.UpdateBorrowing(borrowing);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBorrowing(int id)
        {
            var borrowing = _borrowingService.GetBorrowingById(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            _borrowingService.DeleteBorrowing(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
    public class BorrowBookModel
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
    public class ReturnBookModel
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }

}
