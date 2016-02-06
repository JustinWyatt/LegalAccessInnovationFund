using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LegalAccessInnovationFund.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public DateTime DateRegistered { get; set; }
        public List<Sponsorship> Sponsorships { get; set; }
        public string Name { get; set; }
        public string AboutMeTitle { get; set; }
        public string AboutMeDescription { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public List<string> Photos { get; set; }
        public string Avatar { get; set; }
        public List<string> Links { get; set; }
        public bool IsApproved { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ApplicationUser> Sponsors { get; set; }
        public DbSet<Sponsorship> Sponsorships { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DonationLevel> DonationLevels { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
    }
}