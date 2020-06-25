using System;
using System.Collections.Generic;

namespace WebApplication6.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRole = new HashSet<AccountRole>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Departmentid { get; set; }

        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
