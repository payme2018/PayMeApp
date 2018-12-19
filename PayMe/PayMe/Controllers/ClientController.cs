using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                ClientManager clientManager = new ClientManager();
                clientManager.CreateClient(client);
                TempData["Message"] = "Client Created Successfully";
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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

            }
            var jsonResult = this.Json(clientList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
