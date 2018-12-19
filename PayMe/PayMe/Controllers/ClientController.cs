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
            
            return View(clientList);
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
                //UserManager userManager = new UserManager();
                ////string password = EncryptionLibrary.EncryptText(registration.Password);
                ////string username = Session["Username"].ToString();
                //userManager.CreateUser(client.FirstName, registration.LastName, registration.EmailID, registration.DateofJoining, registration.Birthdate
                //    , registration.Designation, registration.EmployeeCode, registration.Gender, registration.Username, password, registration.RoleID, username);

                // TODO: Add insert logic here
                TempData["MessageRegistration"] = "Data Saved Successfully!";
               // return RedirectToAction("Register");

                return RedirectToAction("Index");
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
    }
}
