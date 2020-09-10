namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnnotationsToEmployeeId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
