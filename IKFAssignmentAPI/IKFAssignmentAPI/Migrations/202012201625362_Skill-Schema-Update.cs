﻿namespace IKFAssignmentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillSchemaUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "SkillName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "SkillName", c => c.Int(nullable: false));
        }
    }
}
