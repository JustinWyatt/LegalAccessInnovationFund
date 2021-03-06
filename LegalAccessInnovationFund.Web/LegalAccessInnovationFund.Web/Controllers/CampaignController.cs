﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LegalAccessInnovationFund.Web.Models;
using LegalAccessInnovationFund.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Core.Objects;
using Braintree;

namespace LegalAccessInnovationFund.Web.Controllers
{
    public class CampaignController : Controller
    {

        BraintreeGateway gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "74g82mvss5tmhynf",
            PublicKey = "64sf2dk5d92x2fgm",
            PrivateKey = "382ca186fef82f6367ab6b637b45108c"
        };

        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public JsonResult GetToken()
        {
            var clientToken = gateway.ClientToken.generate(new ClientTokenRequest());

            return Json(clientToken, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }

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
            var model = db.Users.Where(x => x.Id == userId)
                                .Select(x => new CampaignViewModel()
                                {

                                }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CampaignView(int id)
        {
            var model = db.Campaigns.Find(id);
            var campaign = new CampaignViewModel()
            {
                Goal = model.Goal,

            };
            return View(campaign);
        }

        [HttpGet]
        public JsonResult LatestCampaigns()
        {
            var model = db.Campaigns.OrderByDescending(x => x.DatePosted).Take(5).Select(x => new CampaignViewModel()
            {
                Title = x.Title,
                DatePosted = x.DatePosted.ToString()
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
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
                CampaignStarter = new ProfileViewModel()
                {
                    Name = campaign.CampaignStarter.Name,
                }
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchCampaigns(string search)
        {

            var model = db.Campaigns.Where(x => x.Title.StartsWith(search))
                                    .Where(x => x.CampaignStarter.Name.Contains(search))
                                    .Where(x => x.Category.CategoryName.Contains(search))
                                    .Select(campaign => new CampaignViewModel()
                                    {
                                        Picture = campaign.Picture
                                    }).ToList();

            return Json(model);
        }

        [HttpGet]
        public ActionResult CampaignBegin()
        {
            var currentCampaign = CurrentCampaign.Retrieve();
            return View(currentCampaign);
        }

        [HttpPost]
        public void AddDonationLevels(DonationLevelViewModel donationLevel)
        {
            var currentCampaign = CurrentCampaign.Retrieve();
            currentCampaign.DonationLevels.Add(donationLevel);
            currentCampaign.Save();
        }

        [HttpPost]
        public JsonResult StartCampaign(CampaignViewModel newCampaign)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            var campaign = new Campaign()
            {
                Title = newCampaign.Title,
                Story = newCampaign.Story,
                Goal = (double)newCampaign.Goal,
                Picture = newCampaign.Picture,
                Status = Status.Pending,
                CampaignStarter = user,
                DateEnd = DateTime.Now.AddDays(60)
            };
            foreach (var donationLevel in campaign.DonationLevels)
            {
                donationLevel.Campaign = campaign;
            }
            db.Campaigns.Add(campaign);
            db.SaveChanges();
            return Json(campaign.Id);
        }

        [HttpPost]
        public JsonResult CreditCardContribution(string nonce, string id, ContributionViewModel contribution)
        {
            var amount = (decimal)contribution.Amount;

            var request = new TransactionRequest
            {
                Amount = amount,
                PaymentMethodNonce = nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);

                var newContribution = new Contribution()
                {
                    Campaign = db.Campaigns.Find(id),
                    Amount = contribution.Amount,
                    Contributor = user,
                };

                var campaign = db.Campaigns.Find(id);
                campaign.Contributions.Add(newContribution);
                db.SaveChanges();

                return Json(result.Message);
            };

            var errors = new List<string>();

            foreach (var item in result.Errors.DeepAll())
            {
                errors.Add(item.Message);
            }

            return Json(errors);
        }

        [HttpPost]
        public JsonResult PaypalContribution(string nonce, string id, ContributionViewModel contribution)
        {

            var amount = (decimal)contribution.Amount;

            TransactionRequest request = new TransactionRequest()
            {
                Amount = amount,
                PaymentMethodNonce = nonce,
                OrderId = "Mapped to PayPal Invoice Number",
                Options = new TransactionOptionsRequest()
                {
                    SubmitForSettlement = true,
                    PayPal = new TransactionOptionsPayPalRequest()
                    {
                        CustomField = "PayPal custom field",
                        Description = "Description for PayPal email receipt"
                    }
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);

                var newContribution = new Contribution()
                {
                    Campaign = db.Campaigns.Find(id),
                    Amount = contribution.Amount,
                    Contributor = user,
                };

                var campaign = db.Campaigns.Find(id);
                campaign.Contributions.Add(newContribution);
                db.SaveChanges();

                return Json(result.Message);
            };
            var errors = new List<string>();

            foreach (var item in result.Errors.DeepAll())
            {
                errors.Add(item.Message);
            }
            return Json(errors);
        }
    }
}