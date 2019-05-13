namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Location", "LocationAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "LocationAddress", c => c.String(nullable: false));
        }
    }
}
