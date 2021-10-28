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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            var totalcompanies = DA_Company.GetTotalCompanies();
            var totalusers = DA_User.GetTotalUsers();
            var totaluserapplications = DA_UserApplication.GetTotalUserApplications();

            ViewBag.totalcompanies = totalcompanies;
            ViewBag.totalusers = totalusers;
            ViewBag.totaluserapplications = totaluserapplications;

            var companies = DA_Company.GetAllCompanies();
            ViewBag.companies = companies;

            var users = DA_User.GetAllUsers();
            ViewBag.users = users;

            var userapplications = DA_UserApplication.GetAllUserApplications();
            foreach (var item in userapplications)
            {
                item.User = DA_User.GetUserById(item.UserId);
                item.UserQualification = DA_UserQualification.GetUserQualificationByUserId(item.UserId);
                item.Company = DA_Company.GetCompanyById(item.CompanyId);
            }

            ViewBag.userapplications = userapplications;
            return View();
        }

        public ActionResult ManageCompanies()
        {
            var companies = DA_Company.GetAllCompanies();

            ViewBag.companies = companies;

            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(FormCollection form)
        {
            var CompanyName = Convert.ToString(form["CompanyName"]);
            var CompanyDescription = Convert.ToString(form["CompanyDescription"]);
            var CompanyEmailId = Convert.ToString(form["CompanyEmailId"]);
            var CompanyContact = Convert.ToString(form["CompanyContact"]);
            var JobProfile = Convert.ToString(form["JobProfile"]);
            var JobOpenings = Convert.ToString(form["JobOpenings"]);
            var JobRequirements = Convert.ToString(form["JobRequirements"]);
            var DocAttachment1 = Convert.ToString(form["DocAttachment1"]);
            var DocAttachment2 = Convert.ToString(form["DocAttachment2"]);
            var DocAttachment3 = Convert.ToString(form["DocAttachment3"]);
            var DocAttachment4 = Convert.ToString(form["DocAttachment4"]);
            var SscCriteria = Convert.ToString(form["SscCriteria"]);
            var HscCriteria = Convert.ToString(form["HscCriteria"]);
            var CreatedBy = Convert.ToString(form["AdminName"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var company = new Company();

            company.CompanyName = CompanyName;
            company.CompanyDescription = CompanyDescription;
            company.CompanyEmailId = CompanyEmailId;
            company.CompanyContact = CompanyContact;
            company.JobProfile = JobProfile;
            company.JobOpenings = JobOpenings;
            company.JobRequirements = JobRequirements;
            company.DocAttachment1 = DocAttachment1;
            company.DocAttachment2 = DocAttachment2;
            company.DocAttachment3 = DocAttachment3;
            company.DocAttachment4 = DocAttachment4;
            company.SscCriteria = SscCriteria;
            company.HscCriteria = HscCriteria;
            company.CreatedBy = CreatedBy;
            company.ModifiedBy = ModifiedBy;

            var result = DA_Company.AddCompany(company);
            var status = "";

            if (result == 0)
            {
                status = "Company not Inserted";
            }

            else
            {
                status = "Company Inserted";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageCompanies", "Admin");
        }

        [HttpPost]
        public ActionResult UpdateCompany(FormCollection form)
        {
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var CompanyName = Convert.ToString(form["CompanyNameEdit"]);
            var CompanyDescription = Convert.ToString(form["CompanyDescriptionEdit"]);
            var CompanyEmailId = Convert.ToString(form["CompanyEmailIdEdit"]);
            var CompanyContact = Convert.ToString(form["CompanyContactEdit"]);
            var JobProfile = Convert.ToString(form["JobProfileEdit"]);
            var JobOpenings = Convert.ToString(form["JobOpeningsEdit"]);
            var JobRequirements = Convert.ToString(form["JobRequirementsEdit"]);
            var DocAttachment1 = Convert.ToString(form["DocAttachment1Edit"]);
            var DocAttachment2 = Convert.ToString(form["DocAttachment2Edit"]);
            var DocAttachment3 = Convert.ToString(form["DocAttachment3Edit"]);
            var DocAttachment4 = Convert.ToString(form["DocAttachment4Edit"]);
            var SscCriteria = Convert.ToString(form["SscCriteriaEdit"]);
            var HscCriteria = Convert.ToString(form["HscCriteriaEdit"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var company = new Company();

            company.CompanyId = CompanyId;
            company.CompanyName = CompanyName;
            company.CompanyDescription = CompanyDescription;
            company.CompanyEmailId = CompanyEmailId;
            company.CompanyContact = CompanyContact;
            company.JobProfile = JobProfile;
            company.JobOpenings = JobOpenings;
            company.JobRequirements = JobRequirements;
            company.DocAttachment1 = DocAttachment1;
            company.DocAttachment2 = DocAttachment2;
            company.DocAttachment3 = DocAttachment3;
            company.DocAttachment4 = DocAttachment4;
            company.SscCriteria = SscCriteria;
            company.HscCriteria = HscCriteria;
            company.ModifiedBy = ModifiedBy;

            var result = DA_Company.UpdateCompany(company);
            var status = "";

            if (result == 0)
            {
                status = "Company not Updated";
            }

            else
            {
                status = "Company Updated";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageCompanies", "Admin");
        }


        [HttpPost]
        public ActionResult DeleteCompany(FormCollection form)
        {
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var company = new Company();
            var userapplication = new UserApplication();
            var userschedule = new UserSchedule();


            company.CompanyId = CompanyId;
            company.ModifiedBy = ModifiedBy;

            userapplication.CompanyId = CompanyId;
            userapplication.ModifiedBy = ModifiedBy;

            userschedule.CompanyId = CompanyId;
            userschedule.ModifiedBy = ModifiedBy;

            var result = DA_Company.DeleteCompany(company);
            var status = "";

            if (result == 0)
            {
                status = "Company not Deleted";
            }

            else
            {
                DA_UserApplication.DeleteUserApplicationByCompanyId(userapplication);
                DA_UserSchedule.DeleteUserScheduleByCompanyId(userschedule);

                status = "Company Deleted";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageCompanies", "Admin");
        }


        public ActionResult ManageUsers()
        {
            var users = DA_User.GetAllUsers();

            ViewBag.users = users;

            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(FormCollection form)
        {
            var UserId = Convert.ToInt32(form["UserId"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var user = new User();
            var userqualification = new UserQualification();
            var userapplication = new UserApplication();
            var userschedule = new UserSchedule();

            user.UserId = UserId;
            user.ModifiedBy = ModifiedBy;

            userqualification.UserId = UserId;
            userqualification.ModifiedBy = ModifiedBy;

            userapplication.UserId = UserId;
            userapplication.ModifiedBy = ModifiedBy;

            userschedule.UserId = UserId;
            userschedule.ModifiedBy = ModifiedBy;

            var result = DA_User.DeleteUser(user);
            var status = "";

            if (result == 0)
            {
                status = "User not Deleted";
            }

            else
            {
                DA_UserQualification.DeleteUserQualificationByUserId(userqualification);
                DA_UserApplication.DeleteUserApplicationByUserId(userapplication);
                DA_UserSchedule.DeleteUserScheduleByUserId(userschedule);

                status = "User Deleted";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageUsers", "Admin");
        }

        public ActionResult ManageUserApplications()
        {
            var userapplications = DA_UserApplication.GetAllUserApplications();

            foreach (var item in userapplications)
            {
                item.User = DA_User.GetUserById(item.UserId);

                item.UserQualification = DA_UserQualification.GetUserQualificationByUserId(item.UserId);

                item.Company = DA_Company.GetCompanyById(item.CompanyId);

            }


            ViewBag.userapplications = userapplications;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserApplication(FormCollection form)
        {
            var ApplicationId = Convert.ToInt32(form["ApplicationId"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);
            var IsEligible = Convert.ToString(form["IsEligible"]);

            var userapplication = new UserApplication();

            userapplication.ApplicationId = ApplicationId;
            userapplication.ModifiedBy = ModifiedBy;
            userapplication.IsEligible = Convert.ToBoolean(IsEligible);

            var result = DA_UserApplication.UpdateUserApplication(userapplication);
            var status = "";

            if (result == 0)
            {
                status = "Eligibility not Updated";
            }

            else
            {
                status = "Eligibility Updated";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageUserApplications", "Admin");
        }

        public ActionResult ManageUserSchedule()
        {
            var userapplications = DA_UserApplication.GetUserApplicationsByEligibility();

            var userschedules = DA_UserSchedule.GetAllUserSchedules();

            foreach (var item in userapplications)
            {
                item.User = DA_User.GetUserById(item.UserId);

                item.UserQualification = DA_UserQualification.GetUserQualificationByUserId(item.UserId);

                item.Company = DA_Company.GetCompanyById(item.CompanyId);

            }

            foreach (var item2 in userschedules)
            {
                item2.User = DA_User.GetUserById(item2.UserId);

                item2.UserQualification = DA_UserQualification.GetUserQualificationByUserId(item2.UserId);

                item2.Company = DA_Company.GetCompanyById(item2.CompanyId);
            }

            ViewBag.userschedules = userschedules;
            ViewBag.userapplications = userapplications;

            return View();
        }

        [HttpPost]
        public ActionResult AddUserSchedule(FormCollection form)
        {
            var UserId = Convert.ToInt32(form["UserId"]);
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var ApplicationId = Convert.ToInt32(form["ApplicationId"]);
            var InterviewName = Convert.ToString(form["InterviewName"]);
            var InterviewDescription = Convert.ToString(form["InterviewDescription"]);
            var InterviewDate = Convert.ToDateTime(form["InterviewDate"]);
            var InterviewDoc1 = Convert.ToString(form["InterviewDoc1"]);
            var InterviewDoc2 = Convert.ToString(form["InterviewDoc2"]);
            var InterviewDoc3 = Convert.ToString(form["InterviewDoc3"]);
            var InterviewDoc4 = Convert.ToString(form["InterviewDoc4"]);
            var CreatedBy = Convert.ToString(form["AdminName"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var userschedule = new UserSchedule();

            userschedule.UserId = UserId;
            userschedule.CompanyId = CompanyId;
            userschedule.ApplicationId = ApplicationId;
            userschedule.InterviewName = InterviewName;
            userschedule.InterviewDescription = InterviewDescription;
            userschedule.InterviewDate = InterviewDate;
            userschedule.InterviewDoc1 = InterviewDoc1;
            userschedule.InterviewDoc2 = InterviewDoc2;
            userschedule.InterviewDoc3 = InterviewDoc3;
            userschedule.InterviewDoc4 = InterviewDoc4;
            userschedule.CreatedBy = CreatedBy;
            userschedule.ModifiedBy = ModifiedBy;

            var result = DA_UserSchedule.AddUserSchedule(userschedule);
            var status = "";

            if (result == 0)
            {
                status = "User Schedule Not Generated";
            }

            else
            {
                status = "User Schedule Generated";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageUserSchedule", "Admin");


        }

        [HttpPost]
        public ActionResult UpdateUserSchedule(FormCollection form)
        {
            var ScheduleId = Convert.ToInt32(form["ScheduleId"]);
            var UserId = Convert.ToInt32(form["UserId"]);
            var CompanyId = Convert.ToInt32(form["CompanyId"]);
            var ApplicationId = Convert.ToInt32(form["ApplicationId"]);
            var InterviewName = Convert.ToString(form["InterviewNameEdit"]);
            var InterviewDescription = Convert.ToString(form["InterviewDescriptionEdit"]);
            var InterviewDate = Convert.ToDateTime(form["InterviewDateEdit"]);
            var InterviewDoc1 = Convert.ToString(form["InterviewDoc1Edit"]);
            var InterviewDoc2 = Convert.ToString(form["InterviewDoc2Edit"]);
            var InterviewDoc3 = Convert.ToString(form["InterviewDoc3Edit"]);
            var InterviewDoc4 = Convert.ToString(form["InterviewDoc4Edit"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var userschedule = new UserSchedule();

            userschedule.ScheduleId = ScheduleId;
            userschedule.UserId = UserId;
            userschedule.CompanyId = CompanyId;
            userschedule.ApplicationId = ApplicationId;
            userschedule.InterviewName = InterviewName;
            userschedule.InterviewDescription = InterviewDescription;
            userschedule.InterviewDate = InterviewDate;
            userschedule.InterviewDoc1 = InterviewDoc1;
            userschedule.InterviewDoc2 = InterviewDoc2;
            userschedule.InterviewDoc3 = InterviewDoc3;
            userschedule.InterviewDoc4 = InterviewDoc4;
            userschedule.ModifiedBy = ModifiedBy;

            var result = DA_UserSchedule.UpdateUserSchedule(userschedule);
            var status = "";

            if (result == 0)
            {
                status = "User Schedule Not Updated";
            }

            else
            {
                status = "User Schedule Updated";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageUserSchedule", "Admin");

        }

        [HttpPost]
        public ActionResult DeleteUserSchedule(FormCollection form)
        {
            var ScheduleId = Convert.ToInt32(form["ScheduleId"]);
            var ModifiedBy = Convert.ToString(form["AdminName"]);

            var userschedule = new UserSchedule();

            userschedule.ScheduleId = ScheduleId;
            userschedule.ModifiedBy = ModifiedBy;

            var result = DA_UserSchedule.DeleteUserSchedule(userschedule);
            var status = "";

            if (result == 0)
            {
                status = "User Schedule Not Deleted";
            }

            else
            {
                status = "User Schedule Deleted";
            }

            ViewBag.Message = status;

            return RedirectToAction("ManageUserSchedule", "Admin");
        }
    }
}