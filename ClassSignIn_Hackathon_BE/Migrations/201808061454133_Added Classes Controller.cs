namespace ClassSignIn_Hackathon_BE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassesController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Pin = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeStamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Pin = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Class_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeStamps", "StudentId", "dbo.Students");
            DropForeignKey("dbo.TimeStamps", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentClasses", new[] { "Class_Id" });
            DropIndex("dbo.StudentClasses", new[] { "Student_Id" });
            DropIndex("dbo.TimeStamps", new[] { "ClassId" });
            DropIndex("dbo.TimeStamps", new[] { "StudentId" });
            DropTable("dbo.StudentClasses");
            DropTable("dbo.TimeStamps");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
