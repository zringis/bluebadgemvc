namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Technician", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Technician", "LocationId");
            AddForeignKey("dbo.Technician", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
            DropColumn("dbo.Technician", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Technician", "Location", c => c.String(nullable: false));
            DropForeignKey("dbo.Technician", "LocationId", "dbo.Location");
            DropIndex("dbo.Technician", new[] { "LocationId" });
            DropColumn("dbo.Technician", "LocationId");
        }
    }
}
