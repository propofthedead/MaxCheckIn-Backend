namespace ClassSignIn_Hackathon_BE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Pin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Classes", "Teacher_Id", c => c.Int());
            CreateIndex("dbo.Classes", "Teacher_Id");
            AddForeignKey("dbo.Classes", "Teacher_Id", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "Teacher_Id" });
            DropColumn("dbo.Classes", "Teacher_Id");
            DropTable("dbo.Teachers");
        }
    }
}
