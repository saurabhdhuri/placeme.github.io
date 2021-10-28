using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMe.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string AdminEmailId { get; set; }

        public string AdminName { get; set; }

        public string Password { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}