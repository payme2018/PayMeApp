using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }

        // GET: Expense/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            ProjectManager projectManager = new ProjectManager();
            ViewBag.Projects = new SelectList(projectManager.GetProjects(), "ID", "ProjectName");
            return View();
           
        }

        // POST: Expense/Create
        [HttpPost]
        public ActionResult Create(ExpenseSummary expenseSummary)
        {
            try
            {
                try
                {
                    ExpenseManager expenseManager = new ExpenseManager();
                    expenseSummary.EmpID = Convert.ToInt32(Session["UserID"]);
                    int value = expenseManager.CreateExpense(expenseSummary);

                    if (value == 1)
                    {
                        TempData["Message"] = "Expense Created Successfully";
                    }
                   
                    else if (value == 0)
                    {
                        TempData["Message"] = "Error Occured";

                    }

                    return RedirectToAction("Index");
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

        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expense/Edit/5
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
        public ActionResult Detail(int id)
        {

            ExpenseManager expenseManager = new ExpenseManager();
            ViewBag.ExpenseSummaryName = expenseManager.GetExpenseSummaryName(id);
            ViewBag.ExpenseSummaryID = id;
            ViewBag.Category = new SelectList(expenseManager.GetExpenseCategory(), "ID", "Name");
            return View();
        }

        // POST: Expense/Edit/5
        [HttpPost]
        public ActionResult Detail(int id, ExpenseDetail expenseDetail)
        {
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();
                expenseDetail.ExpenseSummaryID = id;
                int value = expenseManager.CreateExpenseDetail(expenseDetail);

                if (value == 1)
                {
                    TempData["Message"] = "Expense Detail Created Successfully";
                }

                else if (value == 0)
                {
                    TempData["Message"] = "Error Occured";

                }

                return RedirectToAction("Detail/" + id);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Expense/Delete/5
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

        public JsonResult GetExpenseSummaries()
        {
            IEnumerable<ExpenseSummary> expenseSummaryList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();
                expenseSummaryList = expenseManager.GetExpenseSummaries(Convert.ToInt32(Session["UserID"]));
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(expenseSummaryList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult GetExpenseDetail(int id)
        {
            IEnumerable<ExpenseDetail> expenseDetailList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();
                expenseDetailList = expenseManager.GetExpenseDetailBySummary(id);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(expenseDetailList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
