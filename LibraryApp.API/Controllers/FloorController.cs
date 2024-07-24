using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class FloorController : ApiController
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public IEnumerable<Floor> GetAllFloors()
        {
            return _floorService.GetAllFloors();
        }

        [HttpGet]
        public IHttpActionResult GetFloorById(int id)
        {
            var floor = _floorService.GetFloorById(id);
            if (floor == null)
            {
                return NotFound();
            }
            return Ok(floor);
        }

        [HttpPost]
        public IHttpActionResult AddFloor([FromBody] Floor floor)
        {
            _floorService.AddFloor(floor);
            return CreatedAtRoute("DefaultApi", new { id = floor.FloorId }, floor);
        }

        [HttpPut]
        public IHttpActionResult UpdateFloor(int id, [FromBody] Floor floor)
        {
            if (id != floor.FloorId)
            {
                return BadRequest();
            }

            var existingFloor = _floorService.GetFloorById(id);
            if (existingFloor == null)
            {
                return NotFound();
            }
            _floorService.UpdateFloor(floor);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFloor(int id)
        {
            var floor = _floorService.GetFloorById(id);
            if (floor == null)
            {
                return NotFound();
            }
            _floorService.DeleteFloor(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
