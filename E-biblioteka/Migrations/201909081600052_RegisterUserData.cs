namespace E_biblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "SubscriptionStartDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "SubscriptionEndDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "SubscriptionDurationInMonths", c => c.Int());
            AddColumn("dbo.AspNetUsers", "IsMember", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsMember");
            DropColumn("dbo.AspNetUsers", "SubscriptionDurationInMonths");
            DropColumn("dbo.AspNetUsers", "SubscriptionEndDate");
            DropColumn("dbo.AspNetUsers", "SubscriptionStartDate");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
