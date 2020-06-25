using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class role
    {
        public string getrole(string username)
        {
            using (var context = new authenticationContext())
            {
                string role;

                var s = (from q in context.AccountRole
                        where q.User.Username == username
                        select q.Role.RoleName).SingleOrDefault();
                 role = s.ToString();

                return role;
            }
        }
    }
}
