using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMe.Models
{
    public class UserQualification
    {
        public int QualificationId { get; set; }

        public int UserId { get; set; }

        public string SscPercentage { get; set; }

        public string HscPercentage { get; set; }

        public string UgCourseName { get; set; }

        public string UgPercentage { get; set; }

        public string PgCourseName { get; set; }

        public string PgPercentage { get; set; }

        public string Resume { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}