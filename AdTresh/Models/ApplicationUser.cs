using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTresh.Models
{
    public class ApplicationUser
    {
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}