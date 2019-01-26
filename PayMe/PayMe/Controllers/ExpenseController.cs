using Business;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
                    return Redirect("~/Expense/Index");
                   
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
                ////create path to store in database
                //// expenseDetail.user_image = "~/image/" + expenseDetail.expenseAttachment.FileName;
                //var t = Server.MapPath("Images") + "/" + expenseDetail.expenseAttachment.FileName;
                ////store image in folder
                //expenseDetail.expenseAttachment.SaveAs(Server.MapPath("~/Images") + "/" + expenseDetail.expenseAttachment.FileName);
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(expenseDetail.expenseAttachment.InputStream))
                {
                    bytes = br.ReadBytes(expenseDetail.expenseAttachment.ContentLength);
                }
                string constr = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO ExpenseDetailDocument VALUES (@ExpenseDetailID,@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ExpenseDetailID", value);
                        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(expenseDetail.expenseAttachment.FileName));
                        cmd.Parameters.AddWithValue("@ContentType", expenseDetail.expenseAttachment.ContentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                      
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                TempData["Message"] = "Expense Detail Created Successfully";

                return RedirectToAction("Detail/" + id);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error Occured";
                return View();
            }
        }

   
        public ActionResult DownloadFile(int id)
        {
            byte[] bytes =null;
            string fileName="", contentType="";
            string constr = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM ExpenseDetailDocument WHERE ExpenseDetailID=@ExpenseDetailID";
                    cmd.Parameters.AddWithValue("@ExpenseDetailID", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                        }
                    }
                    con.Close();
                }
            }

            return File(bytes, contentType, fileName);
          
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

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/Images/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}
