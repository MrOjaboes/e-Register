namespace CalvaryCoders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationTogender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            AddColumn("dbo.Students", "MaritalStatus", c => c.Int());
            AlterColumn("dbo.Students", "Gender", c => c.Int());
            DropColumn("dbo.Students", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Course", c => c.String());
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            AlterColumn("dbo.Students", "Gender", c => c.String());
            DropColumn("dbo.Students", "MaritalStatus");
            DropTable("dbo.StudentCourses");
        }
    }
}
