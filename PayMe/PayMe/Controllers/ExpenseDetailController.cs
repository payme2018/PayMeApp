using PayMe.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{

    [ValidateUserSession]
    public class ExpenseDetailController : Controller
    {
        // GET: ExpenseDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExpenseDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpenseDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseDetail/Create
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

        // GET: ExpenseDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpenseDetail/Edit/5
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

        // GET: ExpenseDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
          
        }

        // POST: ExpenseDetail/Delete/5
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
