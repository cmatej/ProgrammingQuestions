namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasSolutionToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "HasSolution", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "HasSolution");
        }
    }
}
