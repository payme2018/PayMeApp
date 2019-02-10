using Business;
using DAL;
using PayMe.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    [ValidateUserSession]
    public class TimeTrackerController : Controller
    {
        // GET: TimeTracker
        public ActionResult Index()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            UserManager userManager = new UserManager();
            TaskManager taskManager = new TaskManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            ViewBag.Employee = new SelectList(userManager.GetUsers(), "EmployeeID", "FirstName");
            ViewBag.Task = new SelectList(taskManager.GetTaskList(null), "ID", "TaskName");
            return View();
           
        }

        // GET: TimeTracker/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeTracker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeTracker/Create
        [HttpPost]
        public ActionResult Create(TimeTracker TimeTracker)
        {
            try
            {
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();
                TimeTracker.CreatedBy = Session["FullName"].ToString();
                int value = timeTrackerManager.CreateTimeTracker(TimeTracker);

                if (value == 1)
                {
                    TempData["Message"] = "Timetracker Created Successfully";
                }

                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult UpdateTimeTracker(int id)
        {
            try
            {
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();
                
               timeTrackerManager.UpdateTimeTrackerCheckoutDate(id);

                var result = new { Success = "true"};
                return Json(result);
            }
            catch
            {
                var result = new { Success = "False"};
                return Json(result);
            }
        }
        // GET: TimeTracker/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeTracker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTracker/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeTracker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetTimeTracker()
        {
            IEnumerable<TimeTracker> timeTrackerList = null;
            try
            {
                TimeTrackerManager timeTrackerManager = new TimeTrackerManager();
                timeTrackerList = timeTrackerManager.GetTimeTracker();
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(timeTrackerList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
