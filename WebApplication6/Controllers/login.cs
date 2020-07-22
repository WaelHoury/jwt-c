using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;
using WebApplication6.Views;
namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class logincontroller : ControllerBase
    {
        verify v = new verify();
        role r = new role();
        phone p = new phone();
        email e = new email();
        deptid d = new deptid();
        getPass g = new getPass();
        private readonly authenticationContext _context;
        public logincontroller(authenticationContext context) => _context = context;
        
        [HttpGet]
        public String getpass2([FromBody]user user1)
        {
            return g.getpass(user1.Username);
        }

        [HttpPost]
        public IActionResult Login([FromBody]user user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            if (v.verif(user.Username, user.Password)==false)
            {
                return BadRequest("Invalid client request1");
            }
            if (v.verif(user.Username, user.Password) == true)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, user.Username),
                   new Claim(ClaimTypes.Role, r.getrole(user.Username)),
                   new Claim(ClaimTypes.Email,e.getemail(user.Username)),
                   new Claim(ClaimTypes.MobilePhone,p.getphone(user.Username)),
                   new Claim(ClaimTypes.GroupSid,d.getdeptid(user.Username))
                 };
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4200/",
                    audience: "http://localhost:4200/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
