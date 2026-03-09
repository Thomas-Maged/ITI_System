using ITI_Entities.Data;
using ITI_Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Repo
{
    public class AccountRepo
    {
        ITI_Context db;
        public AccountRepo(ITI_Context _db)
        {
            db = _db;
        }

        public User getByUserName(string userName)
        {
            User user = db.Users.Include(u=>u.Roles).FirstOrDefault(u => u.UserName == userName);
            return user;
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        
        public Role GetRoleByName(string roleName)
        {
            Role role = db.Roles.FirstOrDefault(r => r.RoleName == roleName);
            return role;
        }

    }
}
