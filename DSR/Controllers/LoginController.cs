using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Domain;
using Common.Helpers;

namespace DSR.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LogOut()
        {

            Session["Id"] = null;
            Session["RoleId"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult SessionExpire()
        {
            return View();
        }

        public JsonResult Authentication(string LoginId,string Password)
        {
            UsersManager usersManager = new UsersManager();

            var result=usersManager.UserAuthenticate(LoginId, Password);
            if(result.IsValid)
            {
                Session["Id"] = result.Id;
                Session["RoleId"] = result.RoleId;
                Session["UserName"] = result.UserName;
               
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}