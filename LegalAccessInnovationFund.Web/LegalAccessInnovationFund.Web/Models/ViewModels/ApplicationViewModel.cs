using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }
    }
}