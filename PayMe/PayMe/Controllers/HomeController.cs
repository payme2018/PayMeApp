﻿using Business;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int accountId = Convert.ToInt32(Session["AccountID"]);
            AccountManager oAccountManager = new AccountManager();
            AccountSummary oAccountSummary = oAccountManager.GetAccountSummary(accountId);
            ViewBag.ClientCount = oAccountSummary.ClientCount;
            ViewBag.EmployeeCount = oAccountSummary.EmployeeCount;
            ViewBag.ProjectCount = oAccountSummary.ProjectCount;
            ViewBag.TotalHourIncurrentMonth = oAccountSummary.TotalHourIncurrentMonth;
            ViewBag.CurrentMonth = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public JsonResult GetAccountExpenseSummaries()
        {
            IEnumerable<AccountExpenseSummary> expenseSummaryList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();
                expenseSummaryList = expenseManager.ExpenseSummeryReportByAccount(Convert.ToInt32(Session["AccountID"]), DateTime.Now.Year, DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(expenseSummaryList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetAccountTimeSheetSummaries()
        {
            IEnumerable<TimeSheetSummary> expenseSummaryList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();

                expenseSummaryList = new TimesheetManager().TimesheetSummaryByAccount(Convert.ToInt32(Session["AccountID"]), DateTime.Now.Year, DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;

            }
            var jsonResult = this.Json(expenseSummaryList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}