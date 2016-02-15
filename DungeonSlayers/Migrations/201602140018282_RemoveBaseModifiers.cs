namespace DungeonSlayers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBaseModifiers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modifiers", "Armor_Id1", "dbo.Armors");
            DropForeignKey("dbo.Modifiers", "Weapon_Id1", "dbo.Weapons");
            DropIndex("dbo.Modifiers", new[] { "Armor_Id1" });
            DropIndex("dbo.Modifiers", new[] { "Weapon_Id1" });
            DropColumn("dbo.Modifiers", "Armor_Id1");
            DropColumn("dbo.Modifiers", "Weapon_Id1");
            //RenameColumn(table: "dbo.Modifiers", name: "Armor_Id1", newName: "Armor_Id");
            //RenameColumn(table: "dbo.Modifiers", name: "Weapon_Id1", newName: "Weapon_Id");
        }
        
        public override void Down()
        {
            //RenameColumn(table: "dbo.Modifiers", name: "Weapon_Id", newName: "Weapon_Id1");
            //RenameColumn(table: "dbo.Modifiers", name: "Armor_Id", newName: "Armor_Id1");
            AddColumn("dbo.Modifiers", "Weapon_Id1", c => c.Int());
            AddColumn("dbo.Modifiers", "Armor_Id1", c => c.Int());
            CreateIndex("dbo.Modifiers", "Weapon_Id1");
            CreateIndex("dbo.Modifiers", "Armor_Id1");
            AddForeignKey("dbo.Modifiers", "Weapon_Id1", "dbo.Weapons", "Id");
            AddForeignKey("dbo.Modifiers", "Armor_Id1", "dbo.Armors", "Id");
        }
    }
}
