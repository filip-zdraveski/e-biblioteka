namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredfieldsannotated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author_AuthorId", c => c.Long(nullable: false));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "DateOfBirth", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "SocialSecurityNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "SubscriptionStartDate", c => c.String(nullable: false));
            CreateIndex("dbo.Books", "Author_AuthorId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            AlterColumn("dbo.Members", "SubscriptionStartDate", c => c.String());
            AlterColumn("dbo.Members", "SocialSecurityNumber", c => c.String());
            AlterColumn("dbo.Members", "DateOfBirth", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String());
            AlterColumn("dbo.Books", "Author_AuthorId", c => c.Long());
            AlterColumn("dbo.Books", "Genre", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
            CreateIndex("dbo.Books", "Author_AuthorId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId");
        }
    }
}
