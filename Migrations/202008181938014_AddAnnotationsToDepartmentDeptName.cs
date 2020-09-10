namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToDepartmentDeptName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Deptname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Deptname", c => c.String());
        }
    }
}
