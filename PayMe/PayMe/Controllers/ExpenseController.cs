using Business;
using DAL;
using PayMe.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{

    [ValidateUserSession]
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
            ExpenseDetail obj = new ExpenseDetail();
            obj.HasBill = true;
            ExpenseManager expenseManager = new ExpenseManager();
            ViewBag.ExpenseSummaryName = expenseManager.GetExpenseSummaryName(id);
            ViewBag.ExpenseSummaryID = id;
            ViewBag.Category = new SelectList(expenseManager.GetExpenseCategory(), "ID", "Name");
            return View(obj);
        }

        public ActionResult EditDetail(int id,int ExpenseSummaryID)
        {
            ExpenseDetail obj = new ExpenseDetail();
            return View(obj);
        }

        public ActionResult Upload(int id)
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
                if (expenseDetail.expenseAttachment != null)
                {
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
            byte[] bytes = null;
            string fileName = "", contentType = "";
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
            try
            {
                // TODO: Add update logic here
                ExpenseManager clientManager = new ExpenseManager();
                clientManager.DeleteExpenseDetail(id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Expense/Delete/5
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


        [HttpPost]
        public ActionResult ExpenseSummeryReport(int clientNo, int ProjectNo)
        {
            IEnumerable<ExpenseSummary> expenseSummaryList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();
                expenseSummaryList = expenseManager.ExpenseSummeryReport(clientNo, ProjectNo);
                if (expenseSummaryList.Count() > 0)
                {

                    var jsonResultS = this.Json(expenseSummaryList, JsonRequestBehavior.AllowGet);
                    jsonResultS.MaxJsonLength = int.MaxValue;
                    return jsonResultS;
                }
                else
                {

                    var result = new { Success = "True", Message = "No Data Found" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                var result = new { Success = "False", Message = "Exception: " + sMessage };
                return Json(result, JsonRequestBehavior.AllowGet);

            }

        }


        [HttpPost]
        public ActionResult ExpenseDetailReport(int clientNo, int ProjectNo)
        {
            IEnumerable<ExpenseDetail> expenseDetailList = null;
            try
            {
                ExpenseManager expenseManager = new ExpenseManager();               
                expenseDetailList = expenseManager.ExpenseDetailReport(clientNo, ProjectNo);
                if (expenseDetailList.Count() > 0)
                {

                    var jsonResultS = this.Json(expenseDetailList, JsonRequestBehavior.AllowGet);
                    jsonResultS.MaxJsonLength = int.MaxValue;
                    return jsonResultS;
                }
                else
                {

                    var result = new { Success = "True", Message = "No Data Found" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                var result = new { Success = "False", Message = "Exception: " + sMessage };
                return Json(result, JsonRequestBehavior.AllowGet);

            }

        }


        [HttpPost]
        public JsonResult UploadExcelsheet()
        {
            var id = Request.Params["id"];
            IEnumerable<ExpenseDetail> expenseDetailerrorList = null;

            try
            {
                if (Request.Files.Count > 0)
                {
                    List<string> data = new List<string>();
                    var File = Request.Files[0];
                    string filePath = string.Empty;
                    string path = Server.MapPath("~/Uploads/ExpenseDetail/");
                    //string path = ConfigurationManager.AppSettings["UploadFiles"];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //foreach (HttpPostedFileBase File in fileToUpload)
                    //{
                    filePath = path + Path.GetFileName(File.FileName);
                    string extension = Path.GetExtension(File.FileName);
                    if ((System.IO.File.Exists(filePath)))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    File.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }

                    DataTable dt = new DataTable();
                    conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = ConfigurationManager.AppSettings["SheetName"];
                                connExcel.Close();

                                bool contains = dtExcelSchema.AsEnumerable().Any(row => sheetName == row.Field<String>("TABLE_NAME"));
                                if (contains)
                                {
                                    //Read Data from First Sheet.
                                    connExcel.Open();
                                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    connExcel.Close();
                                }
                                else
                                {
                                    var result = new { Success = "False", Message = "Invalid template. Please check the sheet name" };
                                    return Json(result, JsonRequestBehavior.AllowGet);
                                }
                            }
                        }
                    }


                    if (dt.Rows.Count > 0)
                    {

                        try
                        {
                            ExpenseManager expenseManager = new ExpenseManager();

                            DataTable ExpenseDetailLine = new DataTable("BillingLineItemType");
                            ExpenseDetailLine.Columns.Add("ExpenseSummaryID", typeof(int));
                            ExpenseDetailLine.Columns.Add("Category", typeof(string));
                            ExpenseDetailLine.Columns.Add("BillNo", typeof(string));
                            ExpenseDetailLine.Columns.Add("Amount", typeof(decimal));
                            ExpenseDetailLine.Columns.Add("BillDate", typeof(DateTime));
                            ExpenseDetailLine.Columns.Add("Location", typeof(string));
                            ExpenseDetailLine.Columns.Add("Notes", typeof(string));




                            int j = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow dr = dt.Rows[i];

                                ExpenseDetailLine.Rows.Add();
                                ExpenseDetailLine.Rows[j]["ExpenseSummaryID"] = id;
                                ExpenseDetailLine.Rows[j]["Category"] = dt.Rows[i]["Category"];
                                ExpenseDetailLine.Rows[j]["BillNo"] = dt.Rows[i]["BillNo"];
                                ExpenseDetailLine.Rows[j]["Amount"] = dt.Rows[i]["Amount"];
                                ExpenseDetailLine.Rows[j]["BillDate"] = Convert.ToDateTime(dt.Rows[i]["BillDate"]);
                                ExpenseDetailLine.Rows[j]["Location"] = dt.Rows[i]["Location"];
                                ExpenseDetailLine.Rows[j]["Notes"] = dt.Rows[i]["Notes"];

                                j++;

                            }



                            expenseDetailerrorList = expenseManager.UplodExpenseDetail(ExpenseDetailLine);
                            if (expenseDetailerrorList.Count() > 0)
                            {

                                var jsonResultS = this.Json(expenseDetailerrorList, JsonRequestBehavior.AllowGet);
                                jsonResultS.MaxJsonLength = int.MaxValue;
                                return jsonResultS;
                            }
                            else
                            {

                                var result = new { Success = "True", Message = "Successfully uploaded !!" };
                                return Json(result, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (Exception ex)
                        {
                            string sMessage = ex.Message;
                            //data.Add("<li>Only Excel file format is allowed</li>");
                            //data.Add("<li>"+ sMessage + "</li>");
                            //data.Add("</ul>");
                            //data.ToArray();
                            //return Json(data, JsonRequestBehavior.AllowGet);
                            var result = new { Success = "False", Message = "Invalid template. Please check the template & data format, Error: " + sMessage };
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }


                        /* ### Unreachable code
                        var jsonResult = this.Json(_ProjectBillingSummayDto, JsonRequestBehavior.AllowGet);
                        jsonResult.MaxJsonLength = int.MaxValue;
                        return jsonResult;
                        */

                        //}
                        //data.Add("<ul>");
                        //data.Add("<li>Only Excel file format is allowed</li>");
                        //data.Add("</ul>");
                        //data.ToArray();
                        //return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var result = new { Success = "False", Message = "File should not empty, Please check the file" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var result = new { Success = "False", Message = "File should not empty, Please check the file" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string sMessage = ex.Message;
                //data.Add("<li>Only Excel file format is allowed</li>");
                //data.Add("<li>"+ sMessage + "</li>");
                //data.Add("</ul>");
                //data.ToArray();
                //return Json(data, JsonRequestBehavior.AllowGet);
                var result = new { Success = "False", Message = "Exception: " + sMessage };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }




    }
}
