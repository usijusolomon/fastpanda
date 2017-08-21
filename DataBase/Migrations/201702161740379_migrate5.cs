namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "OverallScore", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionAnswer", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "AskedQuestion", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "StartTime", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "EndTime", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Levels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserMatric", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserLastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserLastName", c => c.String());
            AlterColumn("dbo.Users", "UserFirstName", c => c.String());
            AlterColumn("dbo.Users", "UserMatric", c => c.String());
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "UserPassword", c => c.String());
            AlterColumn("dbo.Levels", "Name", c => c.String());
            AlterColumn("dbo.Faculties", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String());
            AlterColumn("dbo.Courses", "CourseCode", c => c.String());
            AlterColumn("dbo.Tests", "Status", c => c.String());
            AlterColumn("dbo.Tests", "EndTime", c => c.String());
            AlterColumn("dbo.Tests", "StartTime", c => c.String());
            AlterColumn("dbo.Tests", "Name", c => c.String());
            AlterColumn("dbo.Questions", "AskedQuestion", c => c.String());
            AlterColumn("dbo.Answers", "QuestionAnswer", c => c.String());
            DropColumn("dbo.Tests", "OverallScore");
        }
    }
}
