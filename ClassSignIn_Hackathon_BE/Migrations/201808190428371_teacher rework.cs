namespace ClassSignIn_Hackathon_BE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherrework : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentClasses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "Class_Id", "dbo.Classes");
            DropIndex("dbo.StudentClasses", new[] { "Student_Id" });
            DropIndex("dbo.StudentClasses", new[] { "Class_Id" });
            AddColumn("dbo.Students", "Class_Id", c => c.Int());
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
            DropColumn("dbo.Students", "IsAdmin");
            DropTable("dbo.StudentClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Class_Id });
            
            AddColumn("dbo.Students", "IsAdmin", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropColumn("dbo.Students", "Class_Id");
            CreateIndex("dbo.StudentClasses", "Class_Id");
            CreateIndex("dbo.StudentClasses", "Student_Id");
            AddForeignKey("dbo.StudentClasses", "Class_Id", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentClasses", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
