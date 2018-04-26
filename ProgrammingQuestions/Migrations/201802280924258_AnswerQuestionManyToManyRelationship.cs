namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerQuestionManyToManyRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TechnologyQuestions",
                c => new
                    {
                        Technology_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Technology_Id, t.Question_Id })
                .ForeignKey("dbo.Technologies", t => t.Technology_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Technology_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnologyQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TechnologyQuestions", "Technology_Id", "dbo.Technologies");
            DropIndex("dbo.TechnologyQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TechnologyQuestions", new[] { "Technology_Id" });
            DropTable("dbo.TechnologyQuestions");
            DropTable("dbo.Technologies");
        }
    }
}
