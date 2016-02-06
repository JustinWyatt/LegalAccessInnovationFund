using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using LegalAccessInnovationFund.Web.Models;
using LegalAccessInnovationFund.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace LegalAccessInnovationFund.Web.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ApplicationForm()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SubmitApplication(PendingApplication pendingApplication)
        {
            var application = new PendingApplication()
            {
                FirstName = pendingApplication.FirstName,
                LastName = pendingApplication.LastName,
                City = pendingApplication.City,
                State = pendingApplication.State,
                Country = pendingApplication.Country,
                PostalCode = pendingApplication.PostalCode,
                Email = pendingApplication.Email,
                MailingAccount = new MailingAccount(pendingApplication.Email),
                DateApplied = DateTime.Now
            };

            db.PendingApplications.Add(application);
            db.SaveChanges();

            var messageToApplicant = new SendGrid.SendGridMessage();
            messageToApplicant.AddTo(pendingApplication.Email);
            messageToApplicant.From = new MailAddress("");
            messageToApplicant.Subject = $"";
            messageToApplicant.Text = "";

            var messageToAdministrator = new SendGrid.SendGridMessage();
            messageToAdministrator.AddTo("");
            messageToAdministrator.From = new MailAddress("");
            messageToAdministrator.Subject = "";
            messageToAdministrator.Text = "";

            var transportWeb = new SendGrid.Web("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");
            transportWeb.DeliverAsync(messageToApplicant).Wait();
            transportWeb.DeliverAsync(messageToAdministrator).Wait();

            return RedirectToAction("");
        }

        [Authorize]
        [HttpPost]
        public void ConfirmApplication(int pendingApplicationId)
        {
            var app = db.PendingApplications.Find(pendingApplicationId);
            var applicant = new Applicant()
            {
                Name = app.FirstName + app.LastName,
                DateRegistered = DateTime.Now,
                Campaigns = new List<Campaign>(),
                Contributions = new List<Contribution>(),
                City = app.City,
                State = app.State,
                PostalCode = app.PostalCode,
                Links = new List<UserLink>(),
                BirthDate = DateTime.Parse(app.DateOfBirth),
                Email = app.Email
            };
            var password = System.Web.Security.Membership.GeneratePassword(10, 10);
            UserManager.Create(applicant, password);

            var messageToApplicant = new SendGrid.SendGridMessage();
            messageToApplicant.AddTo(applicant.Email);
            messageToApplicant.From = new MailAddress("");
            messageToApplicant.Subject = $"";
            messageToApplicant.Text = "";

            var transportWeb = new SendGrid.Web("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");
            transportWeb.DeliverAsync(messageToApplicant).Wait();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProfileView()
        {
            var userId = User.Identity.GetUserId();
            var model = db.Users.Where(x => x.Id == userId).Select(user => new ProfileViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Contributions = user.Contributions.Select(contribution => new ContributionViewModel
                {
                    Amount = contribution.Amount,
                    Note = contribution.Note,
                    DonationLevel = contribution.DonationLevel.Title,
                    Contributor = contribution.Contributor.Name
                }).ToList(),
                Campaigns = user.Campaigns.Select(campaign => new CampaignViewModel()
                {
                    Title = campaign.Title,
                    Story = campaign.Story,
                    Goal = campaign.Goal,
                    Picture = campaign.Picture,
                    Location = campaign.Location,
                    DonationLevels = campaign.DonationLevels.Select(donationlevel => new DonationLevelViewModel()
                    {
                        Amount = donationlevel.Amount,
                        Title = donationlevel.Title,
                        Description = donationlevel.Description,
                        Quantity = donationlevel.Quantity,
                        DeliveryDate = donationlevel.DeliveryDate.ToShortDateString()

                    }).ToList(),
                    Status = campaign.Status.ToString(),
                    CategoryName = campaign.Category.CategoryName,
                    Contributions = campaign.Contributions.Select(contribution => new ContributionViewModel()
                    {
                        Amount = contribution.Amount,
                        Note = contribution.Note,
                        DonationLevel = contribution.DonationLevel.Title,
                        Contributor = contribution.Contributor.Name

                    }).ToList(),
                    CampaignStarter = campaign.CampaignStarter.Name
                }).ToList()
            });
            return View(model);
        }

        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            var model = db.Users.Where(x => x.Id == userId).Select(user => new ProfileViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Contributions = user.Contributions.Select(contribution => new ContributionViewModel
                {
                    Amount = contribution.Amount,
                    Note = contribution.Note,
                    DonationLevel = contribution.DonationLevel.Title,
                    Contributor = contribution.Contributor.Name
                }).ToList(),
                Campaigns = user.Campaigns.Select(campaign => new CampaignViewModel()
                {
                    Title = campaign.Title,
                    Story = campaign.Story,
                    Goal = campaign.Goal,
                    Picture = campaign.Picture,
                    Location = campaign.Location,
                    DonationLevels = campaign.DonationLevels.Select(donationlevel => new DonationLevelViewModel()
                    {
                        Amount = donationlevel.Amount,
                        Title = donationlevel.Title,
                        Description = donationlevel.Description,
                        Quantity = donationlevel.Quantity,
                        DeliveryDate = donationlevel.DeliveryDate.ToShortDateString()

                    }).ToList(),
                    Status = campaign.Status.ToString(),
                    CategoryName = campaign.Category.CategoryName,
                    Contributions = campaign.Contributions.Select(contribution => new ContributionViewModel()
                    {
                        Amount = contribution.Amount,
                        Note = contribution.Note,
                        DonationLevel = contribution.DonationLevel.Title,
                        Contributor = contribution.Contributor.Name

                    }).ToList(),
                    CampaignStarter = campaign.CampaignStarter.Name
                }).ToList()
            });
            return View();
        }

        public ActionResult RemoveCampaign(int campaignId)
        {
            return View();
        }

        public ActionResult EditCampaign(int campaignId)
        {
            return View();
        }
    }
}