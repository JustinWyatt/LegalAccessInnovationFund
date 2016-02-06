namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavingChanes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Duration", c => c.DateTime(nullable: false));
            AddColumn("dbo.Campaigns", "DateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Campaigns", "AmountFunded", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.PendingApplications", "DateApplied", c => c.DateTime(nullable: false));
            AddColumn("dbo.PendingApplications", "State", c => c.String());
            AddColumn("dbo.PendingApplications", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.PendingApplications", "DateOfBirth", c => c.String());
            DropColumn("dbo.AspNetUsers", "IsApproved");
            DropColumn("dbo.PendingApplications", "DateRegistered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PendingApplications", "DateRegistered", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.PendingApplications", "DateOfBirth");
            DropColumn("dbo.PendingApplications", "Category");
            DropColumn("dbo.PendingApplications", "State");
            DropColumn("dbo.PendingApplications", "DateApplied");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.Campaigns", "AmountFunded");
            DropColumn("dbo.Campaigns", "DateEnd");
            DropColumn("dbo.Campaigns", "Duration");
        }
    }
}
