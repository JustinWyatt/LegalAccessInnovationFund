namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Story = c.String(),
                        Goal = c.Double(nullable: false),
                        Picture = c.String(),
                        Location = c.String(),
                        Status = c.Int(nullable: false),
                        CampaignStarter_Id = c.String(maxLength: 128),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CampaignStarter_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.CampaignStarter_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DateRegistered = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AboutMeTitle = c.String(),
                        AboutMeDescription = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PostalCode = c.Int(nullable: false),
                        AvatarImagePath = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        MailingAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailingAccounts", t => t.MailingAccount_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.MailingAccount_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Note = c.String(),
                        Contributor_Id = c.String(maxLength: 128),
                        DonationLevel_Id = c.Int(),
                        Campaign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Contributor_Id)
                .ForeignKey("dbo.DonationLevels", t => t.DonationLevel_Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .Index(t => t.Contributor_Id)
                .Index(t => t.DonationLevel_Id)
                .Index(t => t.Campaign_Id);
            
            CreateTable(
                "dbo.DonationLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Campaign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .Index(t => t.Campaign_Id);
            
            CreateTable(
                "dbo.UserLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Applicant_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MailingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PendingApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRegistered = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Email = c.String(),
                        MailingAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailingAccounts", t => t.MailingAccount_Id)
                .Index(t => t.MailingAccount_Id);
            
            CreateTable(
                "dbo.ProfilePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PendingApplications", "MailingAccount_Id", "dbo.MailingAccounts");
            DropForeignKey("dbo.Contributions", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Campaigns", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MailingAccount_Id", "dbo.MailingAccounts");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLinks", "Applicant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contributions", "DonationLevel_Id", "dbo.DonationLevels");
            DropForeignKey("dbo.DonationLevels", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Contributions", "Contributor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Campaigns", "CampaignStarter_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PendingApplications", new[] { "MailingAccount_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserLinks", new[] { "Applicant_Id" });
            DropIndex("dbo.DonationLevels", new[] { "Campaign_Id" });
            DropIndex("dbo.Contributions", new[] { "Campaign_Id" });
            DropIndex("dbo.Contributions", new[] { "DonationLevel_Id" });
            DropIndex("dbo.Contributions", new[] { "Contributor_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "MailingAccount_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Campaigns", new[] { "Category_Id" });
            DropIndex("dbo.Campaigns", new[] { "CampaignStarter_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProfilePhotoes");
            DropTable("dbo.PendingApplications");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.MailingAccounts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.UserLinks");
            DropTable("dbo.DonationLevels");
            DropTable("dbo.Contributions");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Campaigns");
        }
    }
}
