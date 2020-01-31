using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Business;
using PayMe.Filters;

namespace PayMe.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTimeTracker()
        {
            IEnumerable<TimeTracker> timeTrackerList = null;
            try
            {
                int accountId = Convert.ToInt32(Session["AccountID"]);
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();
                timeTrackerList = timeTrackerManager.GetTimeTrackerForCheckOut(accountId);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(timeTrackerList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult UpdateTimeTracker(int id)
        {
            try
            {
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();

                timeTrackerManager.UpdateTimeTrackerCheckoutDate(id);

                var result = new { Success = "true" };
                return Json(result);
            }
            catch
            {
                var result = new { Success = "False" };
                return Json(result);
            }
        }
    }
}