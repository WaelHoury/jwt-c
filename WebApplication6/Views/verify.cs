using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class verify
    {
        public Boolean verif(string username, string password)
        {
            string b;
            b = "true";
            
           using (var context = new authenticationContext())
            {

                var s = from q in context.Account
                        where q.Username == username
                        select q;
                if (s.Any())
                {
                    if (password.Equals(b))
                    {

                        return true;
                    }
                    return false;
                }
                else
                {

                    return false;
                }
            }
        }
    }
}
