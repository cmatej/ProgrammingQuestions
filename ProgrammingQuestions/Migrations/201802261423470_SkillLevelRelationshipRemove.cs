namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillLevelRelationshipRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "SkillLevelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SkillLevelId", c => c.Int(nullable: false));
        }
    }
}
