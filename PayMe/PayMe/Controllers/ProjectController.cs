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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ClientManager clientManager = new ClientManager();
            ViewBag.Roles = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            ViewBag.editupdate = -1;
            return View();
          
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                ProjectManager projectManager = new ProjectManager();
                int value = projectManager.CreateProject(project);

                if (value == 1)
                {
                    TempData["Message"] = "Project Created Successfully";
                }
                else if (value == 2)
                {
                    TempData["Message"] = "Project Name already exists";
                   
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

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            ClientManager clientManager = new ClientManager();
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Roles = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            Project project = new Project();
            project = projectManager.GetProjectByID(id);
            ViewBag.editupdate = id;
            return View("Create", project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Project project)
        {
            try
            {
                // TODO: Add update logic here
                ProjectManager projectManager = new ProjectManager();
                projectManager.UpdateProject(project);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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

        public JsonResult GetProjectList()
        {
            IEnumerable<Project> projectList = null;
            try
            {
                ProjectManager projectManager = new ProjectManager();
                projectList = projectManager.GetProjects();
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(projectList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
