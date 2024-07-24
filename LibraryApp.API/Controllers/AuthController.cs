using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryApp.BLL.Services.Abstract;
using LibraryApp.Domains.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;

namespace LibraryApp.API.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IMemberService _memberService;

        public AuthController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        private string GenerateJwtToken(Member member)
        {
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JwtSecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, member.Username),
            new Claim(ClaimTypes.Role, member.Role) // Ensure the role is correctly added
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            var member = _memberService.ValidateUser(model.Username, model.Password);
            if (member == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(member);

            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("api/auth/logout")]
        public IHttpActionResult Logout()
        {
            return Ok("Başarıyla Çıkış Yapıldı");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/admin/secret")]
        public IHttpActionResult GetSecret()
        {
            return Ok("This is a secret for admins only.");
        }

    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
