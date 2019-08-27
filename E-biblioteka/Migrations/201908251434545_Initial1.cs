namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        AuthorsName = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
