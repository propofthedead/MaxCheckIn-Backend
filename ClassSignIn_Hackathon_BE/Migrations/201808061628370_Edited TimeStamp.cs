namespace ClassSignIn_Hackathon_BE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedTimeStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeStamps", "CheckIn", c => c.DateTime());
            AddColumn("dbo.TimeStamps", "CheckOut", c => c.DateTime());
            DropColumn("dbo.TimeStamps", "FirstName");
            DropColumn("dbo.TimeStamps", "LastName");
            DropColumn("dbo.TimeStamps", "UserName");
            DropColumn("dbo.TimeStamps", "Pin");
            DropColumn("dbo.TimeStamps", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeStamps", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.TimeStamps", "Pin", c => c.String(nullable: false));
            AddColumn("dbo.TimeStamps", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.TimeStamps", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.TimeStamps", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.TimeStamps", "CheckOut");
            DropColumn("dbo.TimeStamps", "CheckIn");
        }
    }
}
