using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class CampaignViewModel
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public double Goal { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public List<DonationLevelViewModel> DonationLevels { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }
        public List<ContributionViewModel> Contributions { get; set; }
        public ProfileViewModel CampaignStarter { get; set; }
        public string DatePosted { get; set; }
        public List<CampaignViewModel> RelatedCampaigns { get; set; }
    }
}