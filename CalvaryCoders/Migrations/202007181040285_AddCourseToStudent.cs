namespace CalvaryCoders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Course", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Course");
        }
    }
}
