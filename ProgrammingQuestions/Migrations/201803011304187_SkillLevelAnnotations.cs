namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillLevelAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SkillLevels", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SkillLevels", "Name", c => c.String());
        }
    }
}
