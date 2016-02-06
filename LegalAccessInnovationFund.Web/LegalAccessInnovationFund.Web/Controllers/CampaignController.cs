using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LegalAccessInnovationFund.Web.Models;
using LegalAccessInnovationFund.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace LegalAccessInnovationFund.Web.Controllers
{
    public class CampaignController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campaign
        [HttpGet]
        public ActionResult Campaigns()
        {
            var model = db.Campaigns.ToList().Select(campaign => new CampaignViewModel()
            {
                Title = campaign.Title,
                Story = campaign.Story,
                Goal = campaign.Goal,
                Picture = campaign.Picture,
                Location = campaign.Location,
                DonationLevels = campaign.DonationLevels.Select(x=> new DonationLevelViewModel()
                {
                    
                }).ToList(),
                Status = campaign.Status.ToString(),
                CategoryName = campaign.Category.CategoryName,
                Contributions = campaign.Contributions.Select(contribution => new ContributionViewModel()
                {
                    
                }).ToList(),
                CampaignStarter = campaign.CampaignStarter.Name
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult StartCampaign(CampaignViewModel newCampaign)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            var campaign = new Campaign()
            {
                Title = newCampaign.Title,
                Story = newCampaign.Story,
                Goal = newCampaign.Goal,
                Picture = newCampaign.Picture,
                Location = newCampaign.Location,
                Status = Status.Pending,
                Category = db.Categories.Find(newCampaign.CategoryName),
                CampaignStarter = user
            };

            foreach (var donation in newCampaign.DonationLevels)
            {
                campaign.DonationLevels.Add(new DonationLevel()
                {
                    Amount = donation.Amount,
                    Title = donation.Title,
                    Description = donation.Description,
                    Quantity = donation.Quantity,
                    DeliveryDate = DateTime.Parse(donation.DeliveryDate),
                    Campaign = campaign
                });
            }

            user.Campaigns.Add(campaign);
            db.SaveChanges();
            return RedirectToAction("");
        }

        [HttpPost]
        public ActionResult MakeContribution(int campaignId)
        {
            var contribution = new Contribution()
            {
                
            };

            var campaign = db.Campaigns.Find(campaignId);
            campaign.Contributions.Add(contribution);
            db.SaveChanges();
            return RedirectToAction("");
        }


    }
}