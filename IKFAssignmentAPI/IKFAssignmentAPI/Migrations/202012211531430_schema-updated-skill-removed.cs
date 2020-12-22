namespace IKFAssignmentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schemaupdatedskillremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Skill_SkillId", "dbo.Skills");
            DropIndex("dbo.Users", new[] { "Skill_SkillId" });
            DropPrimaryKey("dbo.Skills");
            AddColumn("dbo.Users", "Skill", c => c.String());
            AlterColumn("dbo.Skills", "SkillName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Skills", "SkillName");
            DropColumn("dbo.Skills", "SkillId");
            DropColumn("dbo.Users", "Skill_SkillId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Skill_SkillId", c => c.Int());
            AddColumn("dbo.Skills", "SkillId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Skills");
            AlterColumn("dbo.Skills", "SkillName", c => c.String());
            DropColumn("dbo.Users", "Skill");
            AddPrimaryKey("dbo.Skills", "SkillId");
            CreateIndex("dbo.Users", "Skill_SkillId");
            AddForeignKey("dbo.Users", "Skill_SkillId", "dbo.Skills", "SkillId");
        }
    }
}
