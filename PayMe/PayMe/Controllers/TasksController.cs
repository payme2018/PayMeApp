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
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            TempData["Message"] = null;
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(0), "ID", "ProjectName");
            ViewBag.editupdate = -1;
            return View();

        }

        public ActionResult Edit(int id)
        {
            TempData["Message"] = null;
            IEnumerable <Task> projectList = null;
            TaskManager taskManager = new TaskManager();
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            Task model = new Task();

            try
            {
              
                projectList = taskManager.GetTaskListByID(id);
                if(projectList.Count()>0)
                {
                    foreach (var value in projectList)
                    {
                        ViewBag.editupdate = value.ID;
                        model.ClientID = value.ClientID;
                        model.ProjectId = value.ProjectId;
                        model.TaskName = value.TaskName;
                        model.IsActive = value.IsActive;
                    }
                }
                ViewBag.Client = new SelectList(clientManager.GetClients(), "ID", "ClientName");
                ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(model.ClientID), "ID", "ProjectName");               
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            return View("Create", model);
        }


        [HttpPost]
        public ActionResult BindProject(int clientNo)
        {
            ProjectManager projectManager = new ProjectManager();
            int id = Convert.ToInt32(clientNo);
            var lstSiteAdd = ViewBag.Project = new SelectList(projectManager.GetProjectsByClient(clientNo), "ID", "ProjectName");
            var bindingAddresses = new
            {
                project = lstSiteAdd,
            };
            return Json(new { bindingAddresses, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public ActionResult BindTask(int ProjectId)
        {
            TaskManager taskmgr = new TaskManager();
            int id = Convert.ToInt32(ProjectId);
            var lstSiteAdd = ViewBag.Project = new SelectList(taskmgr.GetTaskByProject(ProjectId), "ID", "ProjectName");
            var bindingAddresses = new
            {
                task = lstSiteAdd,
            };
            return Json(new { bindingAddresses, JsonRequestBehavior.AllowGet });
        }


        public JsonResult GetTaskList()
        {
            IEnumerable<Task> projectList = null;
            try
            {
                TaskManager taskManager = new TaskManager();
                projectList = taskManager.GetTaskList(null, Convert.ToInt32(Session["AccountID"]));
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(projectList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult GetTaskListByProject(int? id)
        {
            IEnumerable<Task> projectList = null;
            try
            {
                TaskManager taskManager = new TaskManager();
                projectList = taskManager.GetTaskList(id, Convert.ToInt32(Session["AccountID"]));

                var lstSiteAdd = ViewBag.Task = new SelectList(taskManager.GetTaskList(id, Convert.ToInt32(Session["AccountID"])), "ID", "TaskName");
                var bindingAddresses = new
                {
                    task = lstSiteAdd,
                };
                return Json(new { bindingAddresses, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(projectList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult GetTaskNameByProject(int? id)
        {
            IEnumerable<Task> taskList = null;
            try
            {
                TaskManager taskManager = new TaskManager();
                taskList = taskManager.GetTaskList(id, Convert.ToInt32(Session["AccountID"]));
               
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(taskList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Task task)
        {
            try
            {
                TaskManager taskManager = new TaskManager();
                int value = taskManager.CreateTask(task);

                if (value == 1)
                {
                    TempData["Message"] = "Task Created Successfully";
                }
                else if (value == 2)
                {
                    TempData["Message"] = "Task Name already exists with Same Project";

                }
                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";

                }

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            try
            {
                TaskManager taskManager = new TaskManager();
                int value = taskManager.UpdateTask(task);

                if (value == 1)
                {
                    TempData["Message"] = "Task Updated Successfully";
                }
                else if (value == 2)
                {
                    TempData["Message"] = "Task Name already exists with Same Project";

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

        public ActionResult Delete(int id)
        {
            try
            {
                TaskManager taskManager = new TaskManager();
                int value = taskManager.DeleteTask(id);

                if (value == 1)
                {
                    TempData["Message"] = "Task deleted Successfully";
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


    }
}