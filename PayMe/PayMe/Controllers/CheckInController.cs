using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using DAL;
using PayMe.Filters;

namespace PayMe.Controllers
{
    public class CheckInController : Controller
    {
        // GET: CheckIn
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
                timeTrackerList = timeTrackerManager.GetTimeTrackerForCheckIn(accountId);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(timeTrackerList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        // POST: TimeTracker/Create
        [HttpPost]
        public JsonResult CreateTimeTracker(int clientID , int employeeID , int projectID , int taskID)
        {
            try
            {
                TimeTracker tracker = new TimeTracker();
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();
                tracker.ClientID = clientID;
                tracker.EmployeeID = employeeID;
                tracker.ProjectID = projectID;
                tracker.TaskID = taskID;
                tracker.CreatedOn = DateTime.Now;
                tracker.CheckInDateTime = DateTime.Now;
                tracker.CreatedBy = Session["FullName"].ToString();

                int value = timeTrackerManager.CreateTimeTracker(tracker);

                if (value >= 1)
                {
                    TempData["Message"] = "Timetracker Created Successfully";
                }

                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";

                }

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