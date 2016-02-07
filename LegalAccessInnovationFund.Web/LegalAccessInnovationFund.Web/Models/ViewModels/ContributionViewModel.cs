using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class ContributionViewModel
    {
        public double Amount { get; set; }
        public string Note { get; set; }
        public string DonationLevel { get; set; }
        public ProfileViewModel Contributor { get; set; }
        public string DateContributed { get; set; }
    }
}