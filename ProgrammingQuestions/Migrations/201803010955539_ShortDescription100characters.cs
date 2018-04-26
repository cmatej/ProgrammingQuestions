namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescription100characters : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "ShortDescription", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
