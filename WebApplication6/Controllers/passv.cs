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
    public class passvcontroller : ControllerBase
    {
        getPass g = new getPass();
        private readonly authenticationContext _context;
        public passvcontroller(authenticationContext context) => _context = context;

        [HttpPost]
        public result ver([FromBody] user1 username)
        {
            result a=new result();
            a.resu = g.getpass(username.Username);
            return a;
        }
    }
}
