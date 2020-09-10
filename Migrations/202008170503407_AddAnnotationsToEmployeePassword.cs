namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToEmployeePassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.Int(nullable: false));
        }
    }
}
