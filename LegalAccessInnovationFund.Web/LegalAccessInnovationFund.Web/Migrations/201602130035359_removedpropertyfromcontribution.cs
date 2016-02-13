namespace LegalAccessInnovationFund.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpropertyfromcontribution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "DonationLevel_Id", "dbo.DonationLevels");  
            DropIndex("dbo.Contributions", new[] { "DonationLevel_Id" });
            DropColumn("dbo.Contributions", "DonationLevel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributions", "DonationLevel_Id", c => c.Int());
            CreateIndex("dbo.Contributions", "DonationLevel_Id");
            AddForeignKey("dbo.Contributions", "DonationLevel_Id", "dbo.DonationLevels", "Id");
        }
    }
}
