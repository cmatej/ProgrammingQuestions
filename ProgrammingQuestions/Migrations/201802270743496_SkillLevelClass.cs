namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillLevelClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "SkillLevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "SkillLevelId");
            AddForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "SkillLevels");
            DropColumn("dbo.Questions", "SkillLevelsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SkillLevelsId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "SkillLevels", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels");
            DropIndex("dbo.Questions", new[] { "SkillLevelId" });
            DropColumn("dbo.Questions", "SkillLevelId");
            DropTable("dbo.SkillLevels");
        }
    }
}
