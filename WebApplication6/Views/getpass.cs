using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class getPass
    {
        public string getpass(string username)
        {
            using (var context = new authenticationContext())
            {
                string pass1;

                var s = (from q in context.AccountRole
                         where q.User.Username == username
                         select q.User.Password).SingleOrDefault();
                pass1 = s;

                return pass1;
            }
        }
    }
}
