using Business;
using DAL;
using PayMe.Filters;
using PayMe.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    [ValidateUserSession]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Register
        public ActionResult Register()
        {
            UserManager userManager = new UserManager();
            ViewBag.Roles = new SelectList(userManager.GetRoleList(), "RoleID", "RoleName"); 
            return View();
        }

        // POST: Employee/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registration registration)
        {
            try
            {
                UserManager userManager = new UserManager();
                string password = EncryptionLibrary.EncryptText(registration.Password);
                string username = Session["Username"].ToString();
                int value =userManager.CreateUser(registration.FirstName, registration.LastName, registration.EmailID, registration.DateofJoining, registration.Birthdate
                    , registration.Designation, registration.EmployeeCode, registration.Gender, registration.Username, password, registration.RoleID, username);
                if (value == 1)
                {
                    TempData["MessageRegistration"] = "User Created Successfully";
                    return RedirectToAction("Index");
                }
                else if (value == 2)
                {
                    TempData["MessageRegistration"] = " EmailID already exist";

                }
                else if (value == 3)
                {
                    TempData["MessageRegistration"] = " Username already exist";

                }
                else if (value == 0)
                {
                    TempData["MessageRegistration"] = "Error Occured";

                }
                ViewBag.Roles = new SelectList(userManager.GetRoleList(), "RoleID", "RoleName");
                return View(registration);

            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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
        public JsonResult GetUserList()
        {
            IEnumerable<Registration> userList = null;
            try
            {
                UserManager userManager = new UserManager();
                userList = userManager.GetUsers();
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(userList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");//
            }
            catch
            {
                return View();
            }
        }
    }
}
