namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApprovedToQuestionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Approved");
        }
    }
}
