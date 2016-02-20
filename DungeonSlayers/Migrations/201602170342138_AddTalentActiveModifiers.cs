namespace DungeonSlayers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTalentActiveModifiers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modifiers", "Talent_Id2", c => c.Int());
            CreateIndex("dbo.Modifiers", "Talent_Id2");
            AddForeignKey("dbo.Modifiers", "Talent_Id2", "dbo.Talents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modifiers", "Talent_Id2", "dbo.Talents");
            DropIndex("dbo.Modifiers", new[] { "Talent_Id2" });
            DropColumn("dbo.Modifiers", "Talent_Id2");
        }
    }
}
