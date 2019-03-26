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
    public class TimesheetController : Controller
    {
        // GET: Timesheet
        public ActionResult Index()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            UserManager userManager = new UserManager();
            TaskManager taskManager = new TaskManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            ViewBag.Employee = new SelectList(userManager.GetUsers(), "EmployeeID", "FullName");
            ViewBag.Task = new SelectList(taskManager.GetTaskList(null, Convert.ToInt32(Session["AccountID"])), "ID", "TaskName");
           

            return View();
        }

        // GET: Timesheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Timesheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timesheet/Create
        [HttpPost]
        public ActionResult Create(Timesheet timesheet)
        {
            try
            {
                TimesheetManager timesheetManager = new TimesheetManager();
                timesheet.fkEmpId = Convert.ToInt32(Session["UserID"]);
                timesheet.CreatedBy = Session["FullName"].ToString();
                var x = timesheetManager.CreateTimesheet(timesheet);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Timesheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Timesheet/Edit/5
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

        // GET: Timesheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Timesheet/Delete/5
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
        [HttpGet]
        public JsonResult GetTimesheetEntries()
        {
            IEnumerable<Timesheet> timesheetList = null;
            try
            {
                TimesheetManager timesheetManager = new TimesheetManager();
                timesheetList = timesheetManager.GetTimesheetEntries(Convert.ToInt32(Session["AccountID"]));
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(timesheetList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public void CreateTimesheet(Timesheet timesheet)
        {
           
            try
            {
                TimesheetManager timesheetManager = new TimesheetManager();
                timesheet.fkEmpId = Convert.ToInt32(Session["UserID"]);
                timesheet.CreatedBy = Session["FullName"].ToString();
                var x = timesheetManager.CreateTimesheet(timesheet);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            
        }
    }
}
