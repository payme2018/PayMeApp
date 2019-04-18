using Business;
using DAL;
using PayMe.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace PayMe.Controllers
{
    public class LoginController : Controller
    {
        ILog logger = log4net.LogManager.GetLogger("ErrorLog");
       
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            try
            {
               

                if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Username;
                    var password = EncryptionLibrary.EncryptText(loginViewModel.Password);

                    UserManager userManager = new UserManager();
                    var result = userManager.ValidateUser(Username, password);

                    if (result != null)
                    {
                        if (result.EmployeeID == 0 || result.EmployeeID < 0)
                        {
                            ViewBag.errormessage = "Invalid Username or Password";
                        }
                        else
                        {
                            var RoleID = result.RoleID;
                            AccountManager accountManager = new AccountManager();
                            var accountList = accountManager.GetAccounts();
                           
                            Session["RoleID"] = result.RoleID;
                            Session["Username"] = Convert.ToString(result.Username);
                            Session["FullName"] = result.FirstName + " " + result.LastName;
                            Session["UserID"] = result.EmployeeID;
                            if (Convert.ToInt32(Session["RoleID"]) == 3)
                            {
                                var takeFirstAccount = accountList.OrderBy(x => x.Name).FirstOrDefault();
                                Session["Accounts"] = new SelectList(accountList, "ID", "Name");
                                Session["AccountID"] = takeFirstAccount.ID;
                            }
                            else
                            {
                                accountList = accountList.Where(x => x.ID == result.AccountID).ToList();
                                var takeFirstAccount = accountList.Where(x => x.ID == result.AccountID).FirstOrDefault();
                                Session["Accounts"] = new SelectList(accountList, "ID", "Name");
                                Session["AccountID"] = takeFirstAccount.ID;
                            }
                            return RedirectToAction("Index", "Home");
                            //if (RoleID == 1)
                            //{
                            //    Session["AdminUser"] = Convert.ToString(result.RegistrationID);

                            //    if (result.ForceChangePassword == 1)
                            //    {
                            //        return RedirectToAction("ChangePassword", "UserProfile");
                            //    }

                            //    return RedirectToAction("Dashboard", "Admin");
                            //}
                            //else if (RoleID == 2)
                            //{
                            //    if (!_IAssignRoles.CheckIsUserAssignedRole(result.RegistrationID))
                            //    {
                            //        ViewBag.errormessage = "Approval Pending";
                            //        return View(loginViewModel);
                            //    }

                            //    Session["UserID"] = Convert.ToString(result.RegistrationID);

                            //    if (result.ForceChangePassword == 1)
                            //    {
                            //        return RedirectToAction("ChangePassword", "UserProfile");
                            //    }

                            //    return RedirectToAction("Dashboard", "User");
                            //}
                            //else if (RoleID == 3)
                            //{
                            //    Session["SuperAdmin"] = Convert.ToString(result.RegistrationID);
                            //    return RedirectToAction("Dashboard", "SuperAdmin");
                            //}
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "Invalid Username or Password";
                        return View(loginViewModel);
                    }
                }
                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                logger.Error("EX" + ex);
                return View();                
            }
        }
        [HttpPost]
        public JsonResult UpdateAccountSession(int accountId)
        {
            try
            {
                Session["AccountID"] = accountId;
                var result = new { Success = "true" };
                return Json(result);
            }
            catch
            {
                var result = new { Success = "False" };
                return Json(result);
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {

            try
            {
                HttpContext.Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                logger.Error("EX" + ex);
                throw;
            }
        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            try
            {

                if (Request.Cookies["WebTime"] != null)
                {
                    var option = new HttpCookie("WebTime");
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(option);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}