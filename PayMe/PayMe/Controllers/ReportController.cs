using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult ExpensesSummery()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");           
            return View();
        }

        public ActionResult ExpensesDetail()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            return View();
        }


        public ActionResult TimesheetDetail()
        {
            TempData["Message"] = null;
            //ClientManager clientManager = new ClientManager();
            //ProjectManager projectManager = new ProjectManager();
            //ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            //ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            return View();
        }


        [HttpPost]
        public ActionResult TimesheetDetailReport(string FromDate, string ToDate)
        {
            IEnumerable<Timesheet> timesheetList = null;
            try
            {
                TimesheetManager timesheetManager = new TimesheetManager();
                timesheetList = timesheetManager.TimesheetDetailReport(FromDate, ToDate);
                if (timesheetList.Count() > 0)
                {

                    var jsonResultS = this.Json(timesheetList, JsonRequestBehavior.AllowGet);
                    jsonResultS.MaxJsonLength = int.MaxValue;
                    return jsonResultS;
                }
                else
                {

                    var result = new { Success = "True", Message = "No Data Found" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                var result = new { Success = "False", Message = "Exception: " + sMessage };
                return Json(result, JsonRequestBehavior.AllowGet);

            }

        }


        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
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

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
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
    }
}
