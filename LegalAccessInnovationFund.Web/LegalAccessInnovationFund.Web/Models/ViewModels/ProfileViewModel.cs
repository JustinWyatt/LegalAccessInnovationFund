using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
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
        public string Avatar { get; set; }
        public string UserId { get; set; }
    }
}