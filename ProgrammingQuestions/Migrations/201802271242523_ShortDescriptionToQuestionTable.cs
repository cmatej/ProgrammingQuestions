namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionToQuestionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels");
            DropIndex("dbo.Questions", new[] { "SkillLevelId" });
            DropIndex("dbo.Questions", new[] { "CountryId" });
            AddColumn("dbo.Questions", "ShortDescription", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Questions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "SkillLevelId", c => c.Int());
            AlterColumn("dbo.Questions", "CountryId", c => c.Int());
            CreateIndex("dbo.Questions", "SkillLevelId");
            CreateIndex("dbo.Questions", "CountryId");
            AddForeignKey("dbo.Questions", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels");
            DropForeignKey("dbo.Questions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Questions", new[] { "CountryId" });
            DropIndex("dbo.Questions", new[] { "SkillLevelId" });
            AlterColumn("dbo.Questions", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "SkillLevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Description", c => c.String());
            DropColumn("dbo.Questions", "ShortDescription");
            CreateIndex("dbo.Questions", "CountryId");
            CreateIndex("dbo.Questions", "SkillLevelId");
            AddForeignKey("dbo.Questions", "SkillLevelId", "dbo.SkillLevels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
