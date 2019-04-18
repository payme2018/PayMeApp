using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class EmployeePayRateController : Controller
    {
        // GET: EmployeePayRate
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeePayRate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeePayRate/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: EmployeePayRate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeePayRate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // GET: EmployeePayRate/Edit/5
        public ActionResult AddPayRate(int id)
        {
            UserManager userManager = new UserManager();
            var result = userManager.GetEmployeeByID(id);
            ViewBag.EmployeeName = result.FirstName + " " + result.LastName;
            return View();
        }
        [HttpPost]
        public ActionResult AddPayRate(EmployeePayRate collection)
        {
            UserManager userManager = new UserManager();
            userManager.AddPayEmployeePayRate(collection);
            //TempData["Message"] = "Pay Rate Added Successfully";
            return RedirectToAction("edit", "Employee", new { id = collection.ID });
            //return RedirectToAction("/Employee/"+ collection.ID);
        }
        // POST: EmployeePayRate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeePayRate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeePayRate/Delete/5
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
    }
}
