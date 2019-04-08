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
            return (from u in dSRContext.users.ToList()
                    join
                    r in dSRContext.userRole.ToList()
                    on
                    u.RoleId equals r.Id
                    join
                    l in dSRContext.users.ToList()
                    on
                    u.ReportingId equals l.Id
                    select new Users
                    {
                        Id=u.Id,
                        ReportingId=u.ReportingId,
                        ReportingName=l.UserName,
                        RoleId=u.RoleId,
                        RoleName=r.Role,
                        EmailId=u.EmailId,
                        UserName=u.UserName,
                        LoginId=u.LoginId,
                        Password=u.Password,
                        Description=u.Description,
                        IsActive=u.IsActive,
                        Active=u.IsActive==true?"Active":"InActive"
                        
                    }).ToList();


        }
        public List<Users> GetTeamLeads()
        {
          var userDB = dSRContext.users.Where(o => o.RoleId == (int)Enumerations.UserRole.TeamLead).ToList();
                return userDB;

        }



        public Users UserAuthenticate(string LoginId,string Password)
        {
            var Users = dSRContext.users.Where(o => o.LoginId == LoginId && o.Password == Password).FirstOrDefault();
            if(Users != null)
            {
                if(Users.IsActive)
                {
                    Users.IsValid = true;
                }
                else
                {
                    Users.IsValid = false;
                    Users.ErrorMessage = "The logged in User is not active";
                }
                

            }
            else
            {
                Users = new Users();
                Users.IsValid = false;
                Users.ErrorMessage = "Invalid LoginId or Password";
            }
            return Users;
        }
    }
}
