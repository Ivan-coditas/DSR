using Common.Domain;
using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR.Controllers
{
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
            var result=usersManager.Add(user);
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