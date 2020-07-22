using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class phone
    {
        public string getphone(string username)
        {
            using (var context = new authenticationContext())
            {
                string phone;

                var s = (from q in context.AccountRole
                         where q.User.Username == username
                         select q.User.Phone).SingleOrDefault();
                phone = s.ToString();

                return phone;
            }
        }
    }
}
