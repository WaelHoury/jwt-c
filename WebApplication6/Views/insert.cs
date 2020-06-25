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

namespace WebApplication6.Views
{
    public class insert
    {
        public void Insrt(newuser user)
        {
            using (var context = new authenticationContext())
            {
                var user1 = new Account()
                {

                    Username = user.Username,
                    Password = user.Password,
                    Phone = user.Phone,
                    Email = user.Email,
                    Departmentid = user.Departmentid,

                };
                context.Account.Add(user1);
                context.SaveChanges();

                var r1 = from q in context.Role
                         where q.RoleName == user.RoleName
                         select q.RoleId;
                if (r1.Any())
                {

                    var s = (from q in context.Account
                             where q.Username == user.Username 
                             select q.UserId).SingleOrDefault();
                    var assign1 = new AccountRole()
                    {
                        UserId = s,
                        RoleId = r1.SingleOrDefault(),
                    };
                    context.AccountRole.Add(assign1);
                    context.SaveChanges();
                    return;
                }


                var role1 = new Role()
                {

                    RoleName = user.RoleName


                };
                context.Role.Add(role1);
                context.SaveChanges();


                var s1 = (from q in context.Account
                          where q.Username == user.Username 
                          select q.UserId).SingleOrDefault();
                var r = (from q in context.Role
                         where q.RoleName == user.RoleName
                         select q.RoleId).SingleOrDefault();

                var assign = new AccountRole()
                {
                    UserId = s1,
                    RoleId = r,
                };
                context.AccountRole.Add(assign);
                context.SaveChanges();
                return;
            }
            }
            
        }

    }

