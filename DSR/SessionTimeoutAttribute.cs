using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSR
{
    public class SessionTimeoutAttribute: ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["Id"] == null || HttpContext.Current.Session["RoleId"] == null|| HttpContext.Current.Session["UserName"] == null)
            {
                
                filterContext.Result = new RedirectResult("/Login/SessionExpire");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}