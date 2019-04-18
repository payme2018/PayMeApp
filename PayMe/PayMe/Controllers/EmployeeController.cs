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
            TempData["MessageRegistration"] = "";
            UserManager userManager = new UserManager();
            var roleList = userManager.GetRoleList();
            if (Convert.ToInt32(Session["RoleID"]) != 3)
            {
                roleList = roleList.Where(x => x.RoleID != 3).ToList();
            }
            ViewBag.Roles = new SelectList(roleList, "RoleID", "RoleName");
            ViewBag.Managers = new SelectList(userManager.GetManagerList(), "fkManagerId", "Name");
            ViewBag.Locations = new SelectList(userManager.GetLocationList(), "fkEmploymentLocationID", "Name");
            ViewBag.Departments = new SelectList(userManager.GetDepartmentList(), "fkDepartmentID", "Name");
            ViewBag.editupdate = -1;
            return View();
        }

        // POST: Employee/Register
        [HttpPost]
       
        public ActionResult Register(Registration registration)
        {
            try
            {
                UserManager userManager = new UserManager();

              
                registration.CreatedBy = Session["Username"].ToString();
                registration.Password = EncryptionLibrary.EncryptText(registration.Password);
                int value =userManager.CreateUser(registration);
                if (value == 1)
                {
                    TempData["MessageRegistration"] = "User Created Successfully";
                    return RedirectToAction("/Index");
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
                // ViewBag.Roles = new SelectList(userManager.GetRoleList(), "RoleID", "RoleName");
                return RedirectToAction("/Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["MessageRegistration"] = "";
            UserManager userManager = new UserManager();
            ViewBag.Roles = new SelectList(userManager.GetRoleList(), "RoleID", "RoleName");
            ViewBag.Managers = new SelectList(userManager.GetManagerList(), "fkManagerId", "Name");
            ViewBag.Locations = new SelectList(userManager.GetLocationList(), "fkEmploymentLocationID", "Name");
            ViewBag.Departments = new SelectList(userManager.GetDepartmentList(), "fkDepartmentID", "Name");
            Registration registration = new Registration();
            registration = userManager.GetEmployeeByID(id);
            ViewBag.editupdate = id;
            return View("Register", registration);

        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Registration registration)
        {
            try
            {
               
                UserManager userManager = new UserManager();
                int value = userManager.UpdateUser(registration);
                // TODO: Add update logic here
                TempData["MessageRegistration"] = "User Updated Successfully";
                return RedirectToAction("/Index");
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

                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetPayRateByEmployee(int id)
        {
            IEnumerable<EmployeePayRate> employeePayRateList = null;
            try
            {
                UserManager userManager = new UserManager();
                employeePayRateList = userManager.GetPayrateByEmployeeID(id);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(employeePayRateList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
