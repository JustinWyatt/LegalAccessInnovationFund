using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public List<ContributionViewModel> Contributions { get; set; }  
        public List<CampaignViewModel> Campaigns { get; set; }
        public string Email { get; set; }
    }
}