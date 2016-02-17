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

        public ActionResult CampaignAccess()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Test(string data)
        {
            return Json(data);
        }

        [HttpGet]
        public ActionResult OurVision()
        {
            return View();
        }
    }
}