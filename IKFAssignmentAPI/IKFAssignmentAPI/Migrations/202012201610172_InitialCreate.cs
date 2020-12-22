namespace IKFAssignmentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Designation = c.String(),
                        Skill_SkillId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId)
                .Index(t => t.Skill_SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Skill_SkillId", "dbo.Skills");
            DropIndex("dbo.Users", new[] { "Skill_SkillId" });
            DropTable("dbo.Users");
            DropTable("dbo.Skills");
        }
    }
}
