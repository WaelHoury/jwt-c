using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class email
    {
        public string getemail(string username)
        {
            using (var context = new authenticationContext())
            {
                string email;

                var s = (from q in context.AccountRole
                         where q.User.Username == username
                         select q.User.Email).SingleOrDefault();
                email = s.ToString();

                return email;
            }
        }
    }
}
