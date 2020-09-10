namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToEmployeeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
