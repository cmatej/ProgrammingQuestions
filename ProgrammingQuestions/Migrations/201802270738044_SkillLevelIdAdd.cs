namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillLevelIdAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "SkillLevels", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "SkillLevelsId", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "SkillLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SkillLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "SkillLevelsId");
            DropColumn("dbo.Questions", "SkillLevels");
        }
    }
}
