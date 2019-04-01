using Common.Domain;
using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddProject(Projects projects)
        {
            ProjectsManager projectsManager = new ProjectsManager();
            var result=projectsManager.Add(projects);
            return Json(result,JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult UpdateProject(Projects projects)
        {
            ProjectsManager projectsManager = new ProjectsManager();
            projectsManager.Update(projects);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProject(int Id)
        {
            ProjectsManager projectsManager = new ProjectsManager();
            projectsManager.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            ProjectsManager projectsManager = new ProjectsManager();
            var result = projectsManager.GetProjects();
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}