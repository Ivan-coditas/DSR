using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Domain;
using DAL.Manager;

namespace DSR.Controllers
{
    public class TimeSheetController : Controller
    {
        // GET: TimeSheet
        public ActionResult Index()
        {
            return View();
        }

        public void AddTimeSheet(TimeSheet timeSheet)
        {
            TimeSheetManager timeSheetManager = new TimeSheetManager();
            timeSheetManager.Add(timeSheet);
        }

        public JsonResult UpdateTimeSheet(TimeSheet timeSheet)
        {
            TimeSheetManager timeSheetManager = new TimeSheetManager();
            var result=timeSheetManager.Update(timeSheet);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTimeSheet(int Id)
        {
            TimeSheetManager timeSheetManager = new TimeSheetManager();
            timeSheetManager.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTimeSheet()
        {
            TimeSheetManager timeSheetManager = new TimeSheetManager();
           var result= timeSheetManager.GetTimeSheet();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}