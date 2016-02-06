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
            return View();
        }

        [HttpGet]
        public ActionResult MyCampaigns()
        {
            var userId = User.Identity.GetUserId();
            var model = db.Users.Where(x => x.Id == userId).Select(x => new CampaignViewModel()
            {

            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CampaignView(int id)
        {
            var model = db.Campaigns.Where(x => x.Id == id).Select(x => new CampaignViewModel()
            {

            }).ToList();
            return View(model);
        }

        [HttpGet]
        public JsonResult LatestCampaigns()
        {
           var model = db.Campaigns.OrderByDescending(x => x.DatePosted).Take(5).Select(x => new CampaignViewModel()
            {
               Avatar = x.CampaignStarter.AvatarImagePath,
               Title = x.Title,
               DatePosted = x.DatePosted.ToShortDateString()
            }).ToList();
            return Json(model);
        }

        [HttpGet]
        public JsonResult CampaignsJs()
        {
            var model = db.Campaigns.Select(campaign => new CampaignViewModel()
            {
                Title = campaign.Title,
                Story = campaign.Story,
                Goal = campaign.Goal,
                Picture = campaign.Picture,
                Location = campaign.Location,
                DonationLevels = campaign.DonationLevels.Select(donationlevel => new DonationLevelViewModel()
                {

                }).ToList(),
                Status = campaign.Status.ToString(),
                CategoryName = campaign.Category.CategoryName,
                Contributions = campaign.Contributions.Select(contribution => new ContributionViewModel()
                {

                }).ToList(),
                CampaignStarter = campaign.CampaignStarter.Name
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchCampaigns(string search)
        {
            var model = db.Campaigns.Where(x =>x.Title.StartsWith(search))
                                    .Where(x=>x.CampaignStarter.Name.Contains(search))
                                    .Where(x=>x.Category.CategoryName.Contains(search))
                                    .Select(campaign => new CampaignViewModel()
                                    {
                                        Picture = campaign.Picture
                                    }).ToList();
            
            return Json(model);
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
                CampaignStarter = user,
                DateEnd = DateTime.Now.AddDays(60)
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