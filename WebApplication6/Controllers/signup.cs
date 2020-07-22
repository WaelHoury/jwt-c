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
    public class signupcontroller : ControllerBase
    {
        verify v = new verify();
        role r = new role();
        phone p = new phone();
        email e = new email();
        deptid d = new deptid();
        insert ins = new insert();
        private readonly authenticationContext _context;
        public signupcontroller(authenticationContext context) => _context = context;

        [HttpPost]
        public IActionResult signup([FromBody]newuser user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            ins.Insrt(user);
            
            
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, r.getrole(user.Username)),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.MobilePhone,user.Phone.ToString()),
                    new Claim(ClaimTypes.GroupSid,user.Departmentid.ToString())
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
}
}
