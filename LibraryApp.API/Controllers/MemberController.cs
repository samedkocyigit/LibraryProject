using LibraryApp.BLL.Services;
using LibraryApp.Domains.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LibraryApp.API.Controllers
{
    public class MemberController : ApiController
    {
        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IEnumerable<Member> GetAllMembers()
        {
            return _memberService.GetAllMembers();
        }

        [HttpGet]
        public IHttpActionResult GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public IHttpActionResult AddMember([FromBody] Member member)
        {
            _memberService.AddMember(member);
            return CreatedAtRoute("DefaultApi", new { id = member.MemberId }, member);
        }

        [HttpPut]
        public IHttpActionResult UpdateMember(int id, [FromBody] Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            var existingMember = _memberService.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound();
            }
            _memberService.UpdateMember(member);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            _memberService.DeleteMember(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
