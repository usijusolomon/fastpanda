namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "CourseId", c => c.Long(nullable: false));
            CreateIndex("dbo.Tests", "CourseId");
            AddForeignKey("dbo.Tests", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "CourseId", "dbo.Courses");
            DropIndex("dbo.Tests", new[] { "CourseId" });
            DropColumn("dbo.Tests", "CourseId");
        }
    }
}
