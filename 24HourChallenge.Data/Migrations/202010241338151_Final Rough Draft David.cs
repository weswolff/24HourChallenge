namespace _24HourChallenge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalRoughDraftDavid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        OwnerId = c.Guid(nullable: false),
                        Author_UserId = c.Guid(),
                        CommentPost_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Author_UserId)
                .ForeignKey("dbo.Post", t => t.CommentPost_PostId)
                .Index(t => t.Author_UserId)
                .Index(t => t.CommentPost_PostId);
            
            AddColumn("dbo.Post", "isLiked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "CommentPost_PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "Author_UserId", "dbo.User");
            DropIndex("dbo.Comment", new[] { "CommentPost_PostId" });
            DropIndex("dbo.Comment", new[] { "Author_UserId" });
            DropColumn("dbo.Post", "isLiked");
            DropTable("dbo.Comment");
        }
    }
}
