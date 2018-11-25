using Business;
using DAL;
using PayMe.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayMe.Controllers
{
    public class LoginController : Controller
    {
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
                        if (result.RegistrationID == 0 || result.RegistrationID < 0)
                        {
                            ViewBag.errormessage = "Invalid Username or Password";
                        }
                        else
                        {
                            var RoleID = result.RoleID;
                           

                            Session["RoleID"] = Convert.ToString(result.RoleID);
                            Session["Username"] = Convert.ToString(result.Username);
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}