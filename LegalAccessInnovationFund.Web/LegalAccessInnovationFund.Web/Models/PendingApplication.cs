using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models
{
    public class PendingApplication
    {
        public int Id { get; set; }
        public DateTime DateApplied { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ApplicationCategory Category { get; set; }
        public string LawSchool { get; set; }
        public string YearInSchool { get; set; }
        public string PhoneNumber { get; set; }
        public string ResumePath { get; set; }
    }
}