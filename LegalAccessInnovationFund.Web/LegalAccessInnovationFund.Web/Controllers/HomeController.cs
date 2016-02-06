using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LegalAccessInnovationFund.Web.Models;
using LegalAccessInnovationFund.Web.Models.ViewModels;

namespace LegalAccessInnovationFund.Web.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainPage()
        {
            var model = db.Campaigns.Take(12).Select(x => new CampaignViewModel()
            {
                CampaignStarter = x.CampaignStarter.Name,
                Title = x.Title,
                Picture = x.Picture
            }).ToList();
            return View(model);
        }
    }
}