using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class UsersManager
    {
        DSRContext dSRContext = new DSRContext();

        public Users Add(Users users)
        {
            dSRContext.users.Add(users);
            dSRContext.SaveChanges();
            return users;
        }

        public Users Update(Users users)
        {
            Users userdb = dSRContext.users.Where(o=>o.Id==users.Id).First();
            userdb.Id = users.Id;
            userdb.UserName = users.UserName;
            userdb.LoginId = users.LoginId;
            userdb.EmailId = users.EmailId;
            userdb.Password = users.Password;
            userdb.Description = users.Description;

            userdb.IsActive = users.IsActive;
            userdb.RoleId = users.RoleId;
            userdb.ReportingId = users.ReportingId;
            dSRContext.SaveChanges();
            return users;
        }

        public void Delete(int Id)
        {
            Users userdb = dSRContext.users.Where(o => o.Id == Id).First();
            dSRContext.users.Remove(userdb);
            dSRContext.SaveChanges();
          
        }
        public List<Users> GetUsers()

        {
            return dSRContext.users.ToList();
        }
        public List<Users> GetTeamLeads()
        {
            var userDB = dSRContext.users.Where(o => o.RoleId == (int)Enumerations.UserRole.TeamLead).ToList();
                return userDB;

        }
    }
}
