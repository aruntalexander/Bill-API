using Bill_API.DataLayers;
using Bill_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bill_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {

        private readonly BillingDbContext _context;
        public ValuesController(BillingDbContext billingdbcontext)
        {
            _context = billingdbcontext;
        }


        [HttpGet("getName")]
        [AllowAnonymous]
        public IActionResult GetNames()
        {
            var List = _context.Users.ToList();
            return Ok(List);
        }
        [HttpGet("getNameAuthenticate")]
        public IActionResult getNameAuthenticate()
        {
            List<string> names = new List<string> { "Arun", "Akhil" };
            return Ok(_context.Users.ToList());
        }
        [HttpPost("GetToken")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody] Users user)
        {
            if (user.UserName == "arun" && user.Password == "arun") {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name,user.Password)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { token=tokenString});
            } else {
                return Unauthorized("try again");
            }
        }
    }
}
