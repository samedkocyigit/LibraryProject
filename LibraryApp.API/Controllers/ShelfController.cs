using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class ShelfController : ApiController
    {
        private readonly IShelfService _shelfService;

        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        [HttpGet]
        public IEnumerable<Shelf> GetAllShelves()
        {
            return _shelfService.GetAllShelves();
        }

        [HttpGet]
        public IHttpActionResult GetShelfById(int id)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }

        [HttpPost]
        public IHttpActionResult AddShelf([FromBody] Shelf shelf)
        {
            _shelfService.AddShelf(shelf);
            return CreatedAtRoute("DefaultApi", new { id = shelf.ShelfId }, shelf);
        }

        [HttpPut]
        public IHttpActionResult UpdateShelf(int id, [FromBody] Shelf shelf)
        {
            if (id != shelf.ShelfId)
            {
                return BadRequest();
            }

            var existingShelf = _shelfService.GetShelfById(id);
            if (existingShelf == null)
            {
                return NotFound();
            }
            _shelfService.UpdateShelf(shelf);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteShelf(int id)
        {
            var shelf = _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }
            _shelfService.DeleteShelf(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
