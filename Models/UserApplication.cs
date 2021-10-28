using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMe.Models
{
    public class UserApplication
    {
        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public bool IsEligible { get; set; }

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