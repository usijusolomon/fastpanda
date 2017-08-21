namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "QuestionNumber", c => c.Long(nullable: false));
            DropColumn("dbo.Answers", "Label");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Label", c => c.String());
            DropColumn("dbo.Answers", "QuestionNumber");
        }
    }
}
