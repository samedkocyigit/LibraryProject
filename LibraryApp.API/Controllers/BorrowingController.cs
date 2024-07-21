using LibraryApp.BLL.Services;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class BorrowingController : ApiController
    {
        private readonly BorrowingService _borrowingService;

        public BorrowingController(BorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public IEnumerable<Borrowing> GetAllBorrowings()
        {
            return _borrowingService.GetAllBorrowings();
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
}
