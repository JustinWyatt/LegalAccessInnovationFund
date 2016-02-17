namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingPendingApplication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PendingApplications", "MailingAccount_Id", "dbo.MailingAccounts");
            DropIndex("dbo.PendingApplications", new[] { "MailingAccount_Id" });
            AddColumn("dbo.PendingApplications", "LawSchool", c => c.String());
            AddColumn("dbo.PendingApplications", "YearInSchool", c => c.String());
            DropColumn("dbo.PendingApplications", "City");
            DropColumn("dbo.PendingApplications", "Country");
            DropColumn("dbo.PendingApplications", "State");
            DropColumn("dbo.PendingApplications", "PostalCode");
            DropColumn("dbo.PendingApplications", "DateOfBirth");
            DropColumn("dbo.PendingApplications", "MailingAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PendingApplications", "MailingAccount_Id", c => c.Int());
            AddColumn("dbo.PendingApplications", "DateOfBirth", c => c.String());
            AddColumn("dbo.PendingApplications", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.PendingApplications", "State", c => c.String());
            AddColumn("dbo.PendingApplications", "Country", c => c.String());
            AddColumn("dbo.PendingApplications", "City", c => c.String());
            DropColumn("dbo.PendingApplications", "YearInSchool");
            DropColumn("dbo.PendingApplications", "LawSchool");
            CreateIndex("dbo.PendingApplications", "MailingAccount_Id");
            AddForeignKey("dbo.PendingApplications", "MailingAccount_Id", "dbo.MailingAccounts", "Id");
        }
    }
}
