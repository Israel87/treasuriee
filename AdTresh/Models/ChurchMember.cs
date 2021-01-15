using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTresh.Models
{
    public class ChurchMember
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Country { get; set; }
        public string SSClass { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}