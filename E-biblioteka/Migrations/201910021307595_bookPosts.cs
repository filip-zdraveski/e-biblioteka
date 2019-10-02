namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookPosts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Member_MemberId" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        User_Id = c.String(maxLength: 128),
                        Member_MemberId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "Member_MemberId");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "Member_MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
