namespace ProgrammingQuestions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSkillLevel : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO SkillLevels (Name) values ('Junior'), ('Mid Level'), ('Senior'), ('Lead Developer'), ('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
