namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimilarProblemToQuestionTableNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "SimilarProblem", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "SimilarProblem", c => c.Int(nullable: false));
        }
    }
}
