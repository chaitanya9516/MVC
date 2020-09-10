namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogInErrorMessageToEmloyee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "LogInMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "LogInMessage");
        }
    }
}
