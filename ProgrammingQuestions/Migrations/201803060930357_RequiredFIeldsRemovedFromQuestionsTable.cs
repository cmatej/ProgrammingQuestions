namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFIeldsRemovedFromQuestionsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String(maxLength: 100));
            AlterColumn("dbo.Questions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
