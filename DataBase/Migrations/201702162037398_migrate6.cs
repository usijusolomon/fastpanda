namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateTests",
                c => new
                    {
                        CandidateTestId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        TestId = c.Long(),
                        Score = c.Long(nullable: false),
                        DateTaken = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateTestId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TestId);
            
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateTests", "UserId", "dbo.Users");
            DropForeignKey("dbo.CandidateTests", "TestId", "dbo.Tests");
            DropIndex("dbo.CandidateTests", new[] { "TestId" });
            DropIndex("dbo.CandidateTests", new[] { "UserId" });
            DropColumn("dbo.Users", "Email");
            DropTable("dbo.CandidateTests");
        }
    }
}
