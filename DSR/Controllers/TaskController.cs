using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Domain;

using System.Web.Mvc;

namespace DSR.Controllers
{
    public class TaskController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddTask(Task task)
        {
            TaskManager taskManager = new TaskManager();
            var result = taskManager.Add(task);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTask(Task task)
            {
            TaskManager taskManager = new TaskManager();
            var result=taskManager.Update(task);
            return Json(result, JsonRequestBehavior.AllowGet);
}

        public JsonResult DeleteTask(int Id)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTasks()
        {
            TaskManager taskManager = new TaskManager();
            var result = taskManager.GetTasks();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}