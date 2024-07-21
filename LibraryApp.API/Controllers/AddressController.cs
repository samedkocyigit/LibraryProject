using LibraryApp.BLL.Services;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class AddressController : ApiController
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<Address> GetAllAddresses()
        {
            return _addressService.GetAllAddresses();
        }

        [HttpGet]
        public IHttpActionResult GetAddressById(int id)
        {
            var address = _addressService.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public IHttpActionResult AddAddress([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address cannot be null.");
            }
            _addressService.AddAddress(address);
            return CreatedAtRoute("DefaultApi", new { id = address.AddressId }, address);
        }

        [HttpPut]
        public IHttpActionResult UpdateAddress(int id, [FromBody] Address address)
        {
            if (id != address.AddressId)
            {
                return BadRequest("ID mismatch.");
            }

            var existingAddress = _addressService.GetAddressById(id);
            if (existingAddress == null)
            {
                return NotFound();
            }
            _addressService.UpdateAddress(address);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAddress(int id)
        {
            var address = _addressService.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            _addressService.DeleteAddress(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
