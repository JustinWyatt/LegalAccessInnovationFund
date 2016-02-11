namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavingChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PendingApplications", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PendingApplications", "DateOfBirth", c => c.String());
        }
    }
}
