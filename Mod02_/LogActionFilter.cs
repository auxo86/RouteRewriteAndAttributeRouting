using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Routing;

namespace Mod02_
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", 
                filterContext.RouteData);
            //Debug.WriteLine(
            //    "This Event Fired: OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", 
                filterContext.RouteData);
            //Debug.WriteLine(
            //    "This Event Fired: OnActionExecuted");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", 
                filterContext.RouteData);
            //Debug.WriteLine(
            //    "This Event Fired: OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", 
                filterContext.RouteData);
            //Debug.WriteLine(
            //    "This Event Fired: OnResultExecuted");
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller:{1}, action:{2}",
                methodName, controllerName, actionName);
            //Debug.WriteLine(message);
            System.IO.File.AppendAllText(
                HttpContext.Current.Server.MapPath(
                    "~/a.txt"),
                message+"\r\n");
        }

    }
}