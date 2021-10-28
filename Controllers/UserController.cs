using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlaceMe.Models;
using PlaceMe.Data_Access;

namespace PlaceMe.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult HomePage()
        {
            var companies = DA_Company.GetAllCompanies();

            ViewBag.companies = companies;
            return View();
        }

        public ActionResult EditProfile()
        {
            var user = Session["User"] as PlaceMe.Models.User;

            var users = DA_User.GetUserById(user.UserId);

            ViewBag.users = users;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(FormCollection form)
        {
            var UserId = Convert.ToInt32(form["UserId"]);
            var UserFirstName = Convert.ToString(form["UserFirstNameEdit"]);
            var UserLastName = Convert.ToString(form["UserLastNameEdit"]);
            var UserEmailId = Convert.ToString(form["UserEmailIdEdit"]);
            var Password = Convert.ToString(form["ConfirmPasswordEdit"]);
            var UserContact = Convert.ToString(form["UserContactEdit"]);
            var ModifiedBy = Convert.ToString(form["UserFirstNameEdit"]);

            var user = new User();

            user.UserId = UserId;
            user.UserFirstName = UserFirstName;
            user.UserLastName = UserLastName;
            user.UserEmailId = UserEmailId;
            user.Password = Password;
            user.UserContact = UserContact;
            user.ModifiedBy = ModifiedBy;

            var result = DA_User.UpdateUser(user);
            var status = "";

            if (result == 0)
            {
                status = "User Not Updated";
            }
            else
            {
                status = "User Updated";
            }

            ViewBag.Message = status;

            return RedirectToAction("EditProfile", "User");
        }

        public ActionResult QualificationDetails()
        {
            var user = Session["User"] as PlaceMe.Models.User;

            var userqualifications = DA_UserQualification.GetUserQualificationByUserId(user.UserId);

            ViewBag.userqualifications = userqualifications;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserQualification(FormCollection form)
        {
            var UserId = Convert.ToInt32(form["UserId"]);
            var SscPercentage = Convert.ToString(form["SscPercentage"]);
            var HscPercentage = Convert.ToString(form["HscPercentage"]);
            var UgCourseName = Convert.ToString(form["UgCourseName"]);
            var UgPercentage = Convert.ToString(form["UgPercentage"]);
            var PgCourseName = Convert.ToString(form["PgCourseName"]);
            var PgPercentage = Convert.ToString(form["PgPercentage"]);
            var ModifiedBy = Convert.ToString(form["UserFirstName"]);
            var Resume = Convert.ToString(form["Resume"]);

            var userqualification = new UserQualification();

            userqualification.UserId = UserId;
            userqualification.SscPercentage = SscPercentage;
            userqualification.HscPercentage = HscPercentage;
            userqualification.UgCourseName = UgCourseName;
            userqualification.UgPercentage = UgPercentage;
            userqualification.PgCourseName = PgCourseName;
            userqualification.PgPercentage = PgPercentage;
            userqualification.ModifiedBy = ModifiedBy;
            userqualification.Resume = Resume;

            var result = DA_UserQualification.UpdateUserQualification(userqualification);
            var status = "";

            if (result == 0)
            {
                status = "User Qualification Not Updated";
            }
            else
            {
                status = "User Qualification Updated";
            }

            ViewBag.Message = status;

            return RedirectToAction("QualificationDetails", "User");


        }

        public ActionResult Schedule()
        {
            var user = Session["User"] as PlaceMe.Models.User;

            var userschedules = DA_UserSchedule.GetAllUserScheduleByUserId(user.UserId);

            foreach (var item in userschedules)
            {
                item.Company = DA_Company.GetCompanyById(item.CompanyId);
            }
            

            ViewBag.userschedules = userschedules;

            return View();
        }

        [HttpPost]
        public ActionResult CompanyInfo(FormCollection form)
        {
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var UserId = Convert.ToInt32(form["UserId"]);

            var company = DA_Company.GetCompanyById(CompanyId);

            var userapplication = new UserApplication();

            userapplication.UserId = UserId;
            userapplication.CompanyId = CompanyId;

            var userapplications = DA_UserApplication.GetUserApplicationById(userapplication);





            ViewBag.userapplications = userapplications;
            ViewBag.company = company;


            return View();
        }

        [HttpPost]
        public ActionResult AddUserApplication(FormCollection form)
        {
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var UserId = Convert.ToInt32(form["UserId"]);
            var CreatedBy = Convert.ToString(form["UserFirstName"]);
            var ModifiedBy = Convert.ToString(form["UserFirstName"]);

            var userapplication = new UserApplication();

            userapplication.CompanyId = CompanyId;
            userapplication.UserId = UserId;
            userapplication.CreatedBy = CreatedBy;
            userapplication.ModifiedBy = ModifiedBy;


            var status = "";

            var result = DA_UserApplication.AddUserApplication(userapplication);

            if (result == 0)
            {
                status = "Error while Applying";
            }
            else
            {
                status = "Applied successfully";
            }


            ViewBag.Message = status;
            return RedirectToAction("HomePage", "User");
        }

    }
}