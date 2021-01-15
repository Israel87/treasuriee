using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTresh.Models
{
    public class SpecialProject
    {
        public int SpecialProjectID { get; set; }
        public string SpecialProjectName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}