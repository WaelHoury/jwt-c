using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class deptid
    {
        public string getdeptid(string username)
        {
            using (var context = new authenticationContext())
            {
                string deptid;

                var s = (from q in context.AccountRole
                         where q.User.Username == username
                         select q.User.Departmentid).SingleOrDefault();
                deptid = s.ToString();

                return deptid;
            }
        }
    }
}
