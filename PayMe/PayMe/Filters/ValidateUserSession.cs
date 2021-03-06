﻿using log4net;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PayMe.Filters
{
    public class ValidateUserSession : ActionFilterAttribute
    {
        ILog logger = log4net.LogManager.GetLogger("ErrorLog");
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
               
                if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["Username"])))
                {
                    filterContext.Controller.TempData["ErrorMessage"] = "Session has been expired please Login";
                    logger.Info("Session has been expired please Login");
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }
               
            }
            catch (Exception ex)
            {
                logger.Error("EX" + ex);
            }
        }
    }
}