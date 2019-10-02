namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Posts", new[] { "Member_MemberId" });
            DropColumn("dbo.Posts", "Member_MemberId");
            DropTable("dbo.Members");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Surname = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        SubscriptionStartDate = c.String(nullable: false),
                        SubscriptionEndDate = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            AddColumn("dbo.Posts", "Member_MemberId", c => c.Long());
            CreateIndex("dbo.Posts", "Member_MemberId");
            AddForeignKey("dbo.Posts", "Member_MemberId", "dbo.Members", "MemberId");
        }
    }
}
