using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models.ViewModels
{
    public class CurrentCampaign
    {
        public List<DonationLevelViewModel> DonationLevels { get; set; } 

        public string CampaignImage { get; set; }

        public string CampaignStory { get; set; }

        public double Goal { get; set; }

        public string Title { get; set; }

        public void Save()
        {
            HttpContext.Current.Session["currentCampaign"] = this;
        }

        public static CurrentCampaign Retrieve()
        {
            var campaign = (CurrentCampaign)HttpContext.Current.Session["currentCampaign"];

            if (campaign == null)
            {
                campaign = new CurrentCampaign();
                HttpContext.Current.Session["currentCampaign"] = campaign;
                campaign.DonationLevels = new List<DonationLevelViewModel>();
            }

            return campaign;
        }
    }
}