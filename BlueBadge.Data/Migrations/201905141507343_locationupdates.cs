namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Job", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "LocationId");
            CreateIndex("dbo.Job", "LocationId");
            AddForeignKey("dbo.Customer", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Job", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
            DropColumn("dbo.Customer", "Location");
            DropColumn("dbo.Job", "JobLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Job", "JobLocation", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Location", c => c.String(nullable: false));
            DropForeignKey("dbo.Job", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Customer", "LocationId", "dbo.Location");
            DropIndex("dbo.Job", new[] { "LocationId" });
            DropIndex("dbo.Customer", new[] { "LocationId" });
            DropColumn("dbo.Job", "LocationId");
            DropColumn("dbo.Customer", "LocationId");
        }
    }
}
