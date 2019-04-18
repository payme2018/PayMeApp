using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class EmployeeProjectController : Controller
    {
        // GET: EmployeeProject
        public ActionResult Index()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            return View();
        }

        public ActionResult Create()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            TaskManager taskmgr = new TaskManager();
            UserManager user = new UserManager();

            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            ViewBag.Task = new SelectList(taskmgr.GetTaskByProject(0), "ID", "TaskName");
            ViewBag.Employee = new SelectList(user.GetUserForDD(), "ID", "EmployeeName");
            return View();

        }

      

        public ActionResult Delete(int id)
        {
            try
            {
                TaskManager taskManager = new TaskManager();
                int value = taskManager.DeletemployeeProject(id);

                if (value == 1)
                {
                    TempData["Message"] = "Employee removed successfully";
                }
                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";

                }

                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeProject empProject)
        {
            try
            {
                try
                {
                    EmployeeProjectManager empProjectmgr = new EmployeeProjectManager();
                    //expenseSummary.EmpID = Convert.ToInt32(Session["UserID"]);
                    int value = empProjectmgr.AddEmployeeToProject(empProject);

                    if (value == 1)
                    {
                        TempData["Message"] = "Employee  added Successfully";
                    }

                    else if (value == 0)
                    {
                        TempData["Message"] = "Error Occured";

                    }
                    ModelState.Clear();
                    ClientManager clientManager = new ClientManager();
                    ProjectManager projectManager = new ProjectManager();
                    TaskManager taskmgr = new TaskManager();
                    UserManager user = new UserManager();

                    ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
                    ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
                    ViewBag.Task = new SelectList(taskmgr.GetTaskByProject(0), "ID", "TaskName");
                    ViewBag.Employee = new SelectList(user.GetUserForDD(), "ID", "EmployeeName");
                    return View();
                   
                    //return Redirect("~/EmployeeProject/Index");

                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetEmployeeProject(int clientNo, int ProjectNo, bool IsActive)
        {
            IEnumerable<EmployeeProject> empProjectList = null;
            try
            {
                EmployeeProjectManager empProjectManager = new EmployeeProjectManager();
                empProjectList = empProjectManager.GetEmployeeProject(clientNo, ProjectNo,IsActive);
                if (empProjectList.Count() > 0)
                {

                    var jsonResultS = this.Json(empProjectList, JsonRequestBehavior.AllowGet);
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
    }
}