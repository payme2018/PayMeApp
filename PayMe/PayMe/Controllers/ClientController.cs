using Business;
using DAL;
using log4net;
using PayMe.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    [ValidateUserSession]
    public class ClientController : Controller
    {
        ILog logger = log4net.LogManager.GetLogger("ErrorLog");
        // GET: Client
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                logger.Error("EX" + ex);
                return View();
            }
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.editupdate = -1;
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                ClientManager clientManager = new ClientManager();
                int value = clientManager.CreateClient(client);
                if (value == 1)
                {
                    TempData["Message"] = "Client Created Successfully";
                }
                else if (value == 2)
                {
                    TempData["Message"] = "Client Name already exists";
                    return View();
                }
                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";
                    return View();
                }
                return RedirectToAction("/Index", "Client");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            ClientManager clientManager = new ClientManager();
           
            ViewBag.Roles = new SelectList(clientManager.GetClients(), "ID", "ClientName");
            Client client = new Client();
            client = clientManager.GetClientByID(id);
            ViewBag.editupdate = id;
            return View("Create", client);

            //return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                // TODO: Add update logic here
                ClientManager clientManager = new ClientManager();
                clientManager.UpdateClient(client);
                return RedirectToAction("/Index", "Client");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add update logic here
                ClientManager clientManager = new ClientManager();
                clientManager.DeleteClient(id);
                return RedirectToAction("/Index", "Client");
            }
            catch
            {
                return View();
            }
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetClientList()
        {
            IEnumerable<Client> clientList = null;
            try
            {
                ClientManager clientManager = new ClientManager();
                clientList = clientManager.GetClients();
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                logger.Error("EX" + ex);

            }
            var jsonResult = this.Json(clientList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        public JsonResult GetProjectListByClient(int id)
        {
            IEnumerable<Project> projectList = null;
            try
            {
                ProjectManager projectManager = new ProjectManager();
                projectList = projectManager.GetProjectListByClient(id);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                logger.Error("EX" + ex);
            }
            var jsonResult = this.Json(projectList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
