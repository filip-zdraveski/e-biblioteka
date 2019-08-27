namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.Members", "SocialSecurityNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "SocialSecurityNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Members", "PhoneNumber");
        }
    }
}
