using Common.Domain;
using Common.Helpers;
using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR.Controllers
{
    [SessionTimeoutAttribute]
    public class UserController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult User()
        {

            return View();
        }
        public JsonResult GetUserRole()
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            var result=userRoleManager.GetUserRoles();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetTeamLeads()
        {
            UsersManager usersManager = new UsersManager();
            var result=usersManager.GetTeamLeads();
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddUser(Users user)
        {

            UsersManager usersManager = new UsersManager();
            var result = usersManager.Add(user);
            var fromAddress = "ivan.paul@coditas.com";
            var toAddress = result.EmailId;

            string subject = "Daily Status Report";
            string body = "Welcome: " + result.UserName + "\n";
            body += "LogIn Id: " + result.LoginId + "\n";
            body += "Password: \n" + result.Password + "\n";


            SendEmail.SendingMail(fromAddress, toAddress, subject, body);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetUsers()
        {
            UsersManager usersManager = new UsersManager();
            var result = usersManager.GetUsers();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateUser(Users user)
        {
            UsersManager usersManager = new UsersManager();
            var result = usersManager.Update(user);
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult DeleteUser(int Id)
        {
            UsersManager usersManager = new UsersManager();
            usersManager.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}