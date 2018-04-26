namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimilarProblemToQuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "SimilarProblem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "SimilarProblem");
        }
    }
}
