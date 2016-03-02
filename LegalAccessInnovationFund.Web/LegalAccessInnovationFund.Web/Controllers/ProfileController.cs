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
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

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
        [HttpPost]
        public JsonResult SubmitApplication(ApplicationViewModel pendingApplication)
        {

            //if (db.PendingApplications.Any(x=>x.Email == pendingApplication.Email))
            //{
            //    var message = $"There is already an email address matching {pendingApplication.Email}. Your application is pending. We'll send you an email regarding the status of your application";

            //    return Json(message, JsonRequestBehavior.AllowGet);
            //}

            var resumePath = Server.MapPath("~/Resumes/" + pendingApplication.ResumeFile.FileName);
            pendingApplication.ResumeFile.SaveAs(resumePath);

            var application = new PendingApplication()
            {
                FirstName = pendingApplication.FirstName,
                LastName = pendingApplication.LastName,
                Email = pendingApplication.Email,
                DateApplied = DateTime.Now,
                PhoneNumber = pendingApplication.PhoneNumber,
                ResumePath = resumePath
            };

            db.PendingApplications.Add(application);
            db.SaveChanges();

            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Justin Wyatt\\Source\\Repos\\LegalAccessInnovationFund\\file.txt.txt");

            var secret = file.ReadToEnd();

            var emailMessage = new EmailMessage();

            string password = secret;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("justinjwyatt@hotmail.com");
                mail.To.Add(application.Email);
                mail.Subject = $"You Have A New Applicant!";

                mail.Body = emailMessage.MessageToAdministratorOnSubmitApplication.Replace("Enter Name", application.FirstName + "" + application.LastName)
                                                                                  .Replace("Enter Phonenumber", application.PhoneNumber)
                                                                                  .Replace("Enter Date Applied", application.DateApplied.ToShortDateString())
                                                                                  .Replace("Enter Email", application.Email)
                                                                                  .Replace("ApplicationId", application.Id.ToString())
                                                                                  .Replace("Enter LawSchool", application.LawSchool)
                                                                                  .Replace("Enter SchoolYear", application.YearInSchool);

                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient("smtp.live.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("justinjwyatt@hotmail.com", password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            var success = "Your application has been submitted. We will send you a confirmation letter.";

            return Json(success, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAvatar()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var avatar = user.AvatarImagePath;
            if (avatar == null)
            {
                return Json("http://www.designmissionseries.com/dmseries/india/wp-content/uploads/2015/09/user.png", JsonRequestBehavior.AllowGet);

            }
            return Json(avatar, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult NewAvatar(string newAvatarPath)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            user.AvatarImagePath = newAvatarPath;
            db.SaveChanges();

            return Json(newAvatarPath.ToString(), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProfileView()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            var model = new ProfileViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Avatar = user.AvatarImagePath,
                Contributions = user.Contributions.Select(contribution => new ContributionViewModel
                {
                    Amount = contribution.Amount,
                    Note = contribution.Note,
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
                        Contributor = new ProfileViewModel()
                        {
                            Name = contribution.Contributor.Name,
                            Email = contribution.Contributor.Email,
                            Avatar = contribution.Contributor.AvatarImagePath
                        }

                    }).ToList(),
                }).ToList()
            };
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
                        Contributor = new ProfileViewModel()
                        {
                            Name = contribution.Contributor.Name,
                            Email = contribution.Contributor.Email,
                            Avatar = contribution.Contributor.AvatarImagePath
                        }

                    }).ToList(),
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