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
    public class testcontroller : ControllerBase
    {
        verify v = new verify();
        role r = new role();
        private readonly authenticationContext _context;
        public testcontroller(authenticationContext context) => _context = context;
        [HttpPost]
        public String test([FromBody]user user)
        {
            return r.getrole(user.Username );

        }
    }
}

