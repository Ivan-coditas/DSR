using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Authentication(string LoginId,string Password)
        {
            UsersManager usersManager = new UsersManager();
            var result=usersManager.UserAuthenticate(LoginId, Password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}