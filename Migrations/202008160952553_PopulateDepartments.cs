namespace EmpDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments(Id,DeptName,IsActive) VALUES (1,'Finance','True')");
            Sql("INSERT INTO Departments(Id,DeptName,IsActive) VALUES (2,'Accounts','True')");
            Sql("INSERT INTO Departments(Id,DeptName,IsActive) VALUES (3,'HR','True')");
        }
        
        public override void Down()
        {
        }
    }
}
