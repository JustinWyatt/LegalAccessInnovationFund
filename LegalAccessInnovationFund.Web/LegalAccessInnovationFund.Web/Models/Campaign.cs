using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalAccessInnovationFund.Web.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public double Goal { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public List<DonationLevel> DonationLevels { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public List<Contribution> Contributions { get; set; }
        public Applicant CampaignStarter { get; set; }
        public DateTime Duration { get; set; }
        public DateTime DateEnd { get; set; }
        public double AmountFunded { get; set; }
        public DateTime DatePosted { get; set; }
    }
}