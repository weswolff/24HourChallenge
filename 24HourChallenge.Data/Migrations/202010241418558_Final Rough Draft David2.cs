namespace _24HourChallenge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalRoughDraftDavid2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comment", "ReplyComment_Id", c => c.Int());
            CreateIndex("dbo.Comment", "ReplyComment_Id");
            AddForeignKey("dbo.Comment", "ReplyComment_Id", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ReplyComment_Id", "dbo.Comment");
            DropIndex("dbo.Comment", new[] { "ReplyComment_Id" });
            DropColumn("dbo.Comment", "ReplyComment_Id");
            DropColumn("dbo.Comment", "Discriminator");
        }
    }
}
