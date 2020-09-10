namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToEmployeeEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String());
        }
    }
}
