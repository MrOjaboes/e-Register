namespace CalvaryCoders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationToage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "age", c => c.Short(nullable: false));
        }
    }
}
