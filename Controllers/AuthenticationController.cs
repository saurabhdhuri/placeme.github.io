using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PlaceMe.Models;
using PlaceMe.Data_Access;

namespace PlaceMe.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(FormCollection form)
        {
            var AdminEmailId = Convert.ToString(form["AdminEmailId"]);
            var Password = Convert.ToString(form["Password"]);

            var admin = DA_Admin.CheckAdminIfValid(AdminEmailId);
            var message = "";
            if (string.IsNullOrEmpty(admin.AdminEmailId))
            {
                message = "Admin does not exist";
            }
            else if (admin.AdminEmailId != AdminEmailId || admin.Password != Password)
            {
                message = "Invalid Credentials";
            }
            else if ((admin.AdminEmailId == AdminEmailId && admin.Password == Password))
            {
                Session["Admin"] = admin;
                return RedirectToAction("Dashboard", "Admin");
                
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(FormCollection form)
        {
            var UserEmailId = Convert.ToString(form["UserEmailId"]);
            var Password = Convert.ToString(form["Password"]);

            var user = DA_User.CheckUserIfValid(UserEmailId);
            var message = "";
            if (string.IsNullOrEmpty(user.UserEmailId))
            {
                message = "User does not exist";
            }
            else if (user.UserEmailId != UserEmailId || user.Password != Password)
            {
                message = "Invalid Credentials";
            }
            else if ((user.UserEmailId == UserEmailId && user.Password == Password))
            {
                Session["User"] = user;
                return RedirectToAction("HomePage", "User");

            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(FormCollection form)
        {
            var UserFirstName = Convert.ToString(form["UserFirstName"]);
            var CreatedBy = Convert.ToString(form["UserFirstName"]);
            var ModifiedBy = Convert.ToString(form["UserFirstName"]);
            var UserLastName = Convert.ToString(form["UserLastName"]);
            var UserEmailId = Convert.ToString(form["UserEmailId"]);
            var Password = Convert.ToString(form["ConfirmPassword"]);
            var UserContact = Convert.ToString(form["UserContact"]);
            

            var user = new User();
            var userqualification = new UserQualification();

            user.UserFirstName = UserFirstName;
            user.UserLastName = UserLastName;
            user.UserEmailId = UserEmailId;
            user.Password = Password;
            user.UserContact = UserContact;
            user.CreatedBy = CreatedBy;
            user.ModifiedBy = ModifiedBy;

            userqualification.CreatedBy = CreatedBy;
            userqualification.ModifiedBy = ModifiedBy;
            

            var userexist = DA_User.CheckUserIfValid(UserEmailId);
            var status = "";


            if (userexist.UserEmailId == UserEmailId)
            {
                status = "User Email already used.";
            }

            else
            {
                var UserId = DA_User.AddUser(user);

                
                if (UserId == 0)
                {

                    status = "User Not Registered";

                }


                else
                {
                    userqualification.UserId = UserId;
                    
                    var result = DA_UserQualification.AddUserQualification(userqualification);

                    if (result != 0)
                    {
                        status = "New User Registered";
                        return RedirectToAction("UserLogin", "Authentication");
                    }

                    else
                    {
                        status = "User Not Registered";
                    }


                }
            }

            

            ViewBag.Message = status;

            return View();
        }

        public ActionResult AdminLogout()
        {
            Session["Admin"] = null;
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Authentication");

        }

        public ActionResult UserLogout()
        {
            Session["User"] = null;
            Session.Abandon();
            return RedirectToAction("UserLogin", "Authentication");
        }
    }
}