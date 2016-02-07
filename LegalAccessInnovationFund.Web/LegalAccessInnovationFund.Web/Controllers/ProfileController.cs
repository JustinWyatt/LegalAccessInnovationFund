using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using LegalAccessInnovationFund.Web.Models;
using LegalAccessInnovationFund.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Web.UI;
using System.IO;

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

        [HttpGet]
        public ActionResult ApplicationConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SubmitApplication(ApplicationViewModel pendingApplication)
        {
            var application = new PendingApplication()
            {
                FirstName = pendingApplication.FirstName,
                LastName = pendingApplication.LastName,
                State = pendingApplication.State,
                City = pendingApplication.City,
                Country = pendingApplication.Country,
                PostalCode = pendingApplication.PostalCode,
                Email = pendingApplication.Email,
                MailingAccount = new MailingAccount(pendingApplication.Email),
                DateApplied = DateTime.Now
            };

            db.PendingApplications.Add(application);
            db.SaveChanges();

            System.IO.StreamReader file =  new System.IO.StreamReader("C:\\Users\\Asus\\Desktop\\LegalAccessInnovationFund\\secretfile.txt");

            var apiKey = file.ReadToEnd();

            var messageToApplicant = new SendGrid.SendGridMessage();
            messageToApplicant.AddTo(pendingApplication.Email);
            messageToApplicant.From = new MailAddress("donotreply@leglaccessinnovationfund.com");
            messageToApplicant.Subject = $"Thank you for your application {pendingApplication.FirstName} !";
            messageToApplicant.Text = "Thank you for your application. Your application is pending. Once we confirm your application, we will send you an email and passowrd confirmation. Thank you!";

            var messageToAdministrator = new SendGrid.SendGridMessage();
            messageToAdministrator.AddTo("justinjwyatt@hotmail.com");
            messageToAdministrator.From = new MailAddress("donotreply@legalaccessinnovationfund.com");
            messageToAdministrator.Subject = "Another applicant has applied!";
            var emailMessage = new EmailMessage();

            messageToAdministrator.Text = emailMessage.Message;

            var transportWeb = new SendGrid.Web(apiKey);
            transportWeb.DeliverAsync(messageToApplicant).Wait();
            transportWeb.DeliverAsync(messageToAdministrator).Wait();

            return RedirectToAction("ApplicationConfirmation", "Profile");
        }

        [HttpGet]
        public JsonResult ProfileViewJs()
        {
            var userId = User.Identity.GetUserId();
            var model = db.Users.Where(x => x.Id == userId).Select(user => new ProfileViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Avatar = user.AvatarImagePath,
                Contributions = user.Contributions.Select(contribution => new ContributionViewModel
                {
                    Amount = contribution.Amount,
                    Note = contribution.Note,
                    DonationLevel = contribution.DonationLevel.Title,
                    Contributor = new ProfileViewModel()
                    {
                        Name = contribution.Contributor.Name,
                        Email = contribution.Contributor.Email,
                        Avatar = contribution.Contributor.AvatarImagePath
                    }

                }).ToList(),
                Campaigns = user.Campaigns.ToList().Select(campaign => new CampaignViewModel()
                {
                    CampaignId = campaign.Id,
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
                        Contributor = new ProfileViewModel()
                        {
                            Name = contribution.Contributor.Name,
                            Email = contribution.Contributor.Email,
                            Avatar = contribution.Contributor.AvatarImagePath
                        }

                    }).ToList(),
                    CampaignStarter = campaign.CampaignStarter.Name
                }).ToList()
            });
            return Json(model, JsonRequestBehavior.AllowGet);
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
                Avatar = user.AvatarImagePath,
                Contributions = user.Contributions.Select(contribution => new ContributionViewModel
                {
                    Amount = contribution.Amount,
                    Note = contribution.Note,
                    DonationLevel = contribution.DonationLevel.Title,
                    Contributor = new ProfileViewModel()
                    {
                        Name = contribution.Contributor.Name,
                        Email = contribution.Contributor.Email,
                        Avatar = contribution.Contributor.AvatarImagePath
                    }
                }).ToList(),
                Campaigns = user.Campaigns.Select(campaign => new CampaignViewModel()
                {
                    CampaignId = campaign.Id,
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
                        Contributor = new ProfileViewModel()
                        {
                            Name = contribution.Contributor.Name,
                            Email = contribution.Contributor.Email,
                            Avatar = contribution.Contributor.AvatarImagePath
                        }

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
                    Contributor = new ProfileViewModel()
                    {
                        Name = contribution.Contributor.Name,
                        Email = contribution.Contributor.Email,
                        Avatar = contribution.Contributor.AvatarImagePath
                    }
                }).ToList(),
                Campaigns = user.Campaigns.Select(campaign => new CampaignViewModel()
                {
                    Title = campaign.Title,
                    Story = campaign.Story,
                    Goal = campaign.Goal,
                    Picture = campaign.Picture,
                    Location = campaign.Location,
                    DonationLevels = campaign.DonationLevels.ToList().Select(donationlevel => new DonationLevelViewModel()
                    {
                        Amount = donationlevel.Amount,
                        Title = donationlevel.Title,
                        Description = donationlevel.Description,
                        Quantity = donationlevel.Quantity,
                        DeliveryDate = donationlevel.DeliveryDate.ToShortDateString()

                    }).ToList(),
                    Status = campaign.Status.ToString(),
                    CategoryName = campaign.Category.CategoryName,
                    Contributions = campaign.Contributions.ToList().Select(contribution => new ContributionViewModel()
                    {
                        Amount = contribution.Amount,
                        Note = contribution.Note,
                        DonationLevel = contribution.DonationLevel.Title,
                        Contributor = new ProfileViewModel()
                        {
                            Name = contribution.Contributor.Name,
                            Email = contribution.Contributor.Email,
                            Avatar = contribution.Contributor.AvatarImagePath
                        }

                    }).ToList(),
                    CampaignStarter = campaign.CampaignStarter.Name
                }).ToList()
            });
            return View();
        }

        public ActionResult RemoveCampaign(string campaignName)
        {
            var campaign = db.Campaigns.Find(campaignName);
            return View();
        }

        public ActionResult EditCampaign(int campaignId)
        {
            return View();
        }
    }
}