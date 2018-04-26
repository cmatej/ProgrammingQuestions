namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthFIeldRemovedFromQuestionsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String(maxLength: 100));
        }
    }
}
