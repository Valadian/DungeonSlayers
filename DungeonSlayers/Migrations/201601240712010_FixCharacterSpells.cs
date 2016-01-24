namespace DungeonSlayers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCharacterSpells : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spells", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Spells", new[] { "Character_Id" });
            //RenameColumn(table: "dbo.CharacterSpells", name: "Character_Id", newName: "CharacterId");
            CreateTable(
                "dbo.CharacterSpells",
                c => new
                    {
                        CharacterId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                        Equipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CharacterId, t.SpellId })
                .ForeignKey("dbo.Spells", t => t.SpellId, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.SpellId);
            
            AddColumn("dbo.CharacterArmors", "Equipped", c => c.Boolean(nullable: false));
            DropColumn("dbo.Spells", "Character_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Spells", "Character_Id", c => c.Int());
            DropForeignKey("dbo.CharacterSpells", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterSpells", "SpellId", "dbo.Spells");
            DropIndex("dbo.CharacterSpells", new[] { "SpellId" });
            DropIndex("dbo.CharacterSpells", new[] { "CharacterId" });
            DropColumn("dbo.CharacterArmors", "Equipped");
            DropTable("dbo.CharacterSpells");
            RenameColumn(table: "dbo.CharacterSpells", name: "CharacterId", newName: "Character_Id");
            CreateIndex("dbo.Spells", "Character_Id");
            AddForeignKey("dbo.Spells", "Character_Id", "dbo.Characters", "Id");
        }
    }
}
