namespace ClassSignIn_Hackathon_BE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedUserController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Students", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "Email");
        }
    }
}
