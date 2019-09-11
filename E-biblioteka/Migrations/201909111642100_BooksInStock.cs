namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksInStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "InStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "InStock");
        }
    }
}
