namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PendingApplications", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PendingApplications", "PhoneNumber");
        }
    }
}
