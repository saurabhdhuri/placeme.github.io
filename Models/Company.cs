using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMe.Models
{
    public class Company
    {
        
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyEmailId { get; set; }

        public string CompanyContact { get; set; }

        public string JobOpenings { get; set; }

        public string JobProfile { get; set; }

        public string JobRequirements { get; set; }

        public string DocAttachment1 { get; set; }

        public string DocAttachment2 { get; set; }

        public string DocAttachment3 { get; set; }

        public string DocAttachment4 { get; set; }

        public string SscCriteria { get; set; }

        public string HscCriteria { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}