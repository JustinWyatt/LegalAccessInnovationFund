﻿using System;
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
        public string Email { get; set; }
        public string State { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }
    }   
}