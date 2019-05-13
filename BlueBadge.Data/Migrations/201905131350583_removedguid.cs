namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedguid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skill", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skill", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
