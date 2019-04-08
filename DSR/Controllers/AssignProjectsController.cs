using Common.Domain;
using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR.Controllers
{
    public class AssignProjectsController : Controller
    {
        
        // GET: ProjectTeam
        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult AddProjectTeam(AssignProjects projectTeam )
        {
            AssignProjectManager projectTeamManager = new AssignProjectManager();
            var result=projectTeamManager.Add(projectTeam);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetProjectTeam()
        {
            AssignProjectManager projectTeamManager = new AssignProjectManager();
            var result = projectTeamManager.GetProjectTeams();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProjectTeam(AssignProjects projectTeam)
        {
            AssignProjectManager projectTeamManager = new AssignProjectManager();
           var result=projectTeamManager.Update(projectTeam);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProjectTeam(int Id)
        {
            AssignProjectManager projectTeamManager = new AssignProjectManager();
            projectTeamManager.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}