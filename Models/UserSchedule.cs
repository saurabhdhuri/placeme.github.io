using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMe.Models
{
    public class UserSchedule
    {
        public int ScheduleId { get; set; }

        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public int ApplicationId { get; set; }

        public string InterviewName { get; set; }

        public string InterviewDescription { get; set; }

        public DateTime InterviewDate { get; set; }

        public string InterviewDoc1 { get; set; }

        public string InterviewDoc2 { get; set; }

        public string InterviewDoc3 { get; set; }

        public string InterviewDoc4 { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public User User { get; set; }

        public UserQualification UserQualification { get; set; }

        public Company Company { get; set; }

    }
}