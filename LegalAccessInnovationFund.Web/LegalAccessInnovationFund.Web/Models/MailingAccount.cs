﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models
{
    public class MailingAccount
    {
        public MailingAccount(string email)
        {
            email = Email;
        }
        public int Id { get; set; }
        public string Email { get; set; }
    }
}