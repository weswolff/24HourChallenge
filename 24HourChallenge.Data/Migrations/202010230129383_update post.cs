namespace _24HourChallenge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Comment", c => c.String());
            AddColumn("dbo.Post", "IsLiked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "IsLiked");
            DropColumn("dbo.Post", "Comment");
        }
    }
}
