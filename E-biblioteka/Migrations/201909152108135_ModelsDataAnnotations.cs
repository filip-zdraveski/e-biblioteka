namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Surname", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Requests", "AuthorsName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "AuthorsName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Members", "Surname");
        }
    }
}
