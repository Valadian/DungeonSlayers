namespace DungeonSlayers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwapModifierNames : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.Modifiers", name: "Talent_Id", newName: "__mig_tmp__0");
            //RenameColumn(table: "dbo.Modifiers", name: "Talent_Id2", newName: "Talent_Id");
            //RenameColumn(table: "dbo.Modifiers", name: "__mig_tmp__0", newName: "Talent_Id2");
            //RenameIndex(table: "dbo.Modifiers", name: "IX_Talent_Id", newName: "__mig_tmp__0");
            //RenameIndex(table: "dbo.Modifiers", name: "IX_Talent_Id2", newName: "IX_Talent_Id");
            //RenameIndex(table: "dbo.Modifiers", name: "__mig_tmp__0", newName: "IX_Talent_Id2");
        }
        
        public override void Down()
        {
            //RenameIndex(table: "dbo.Modifiers", name: "IX_Talent_Id2", newName: "__mig_tmp__0");
            //RenameIndex(table: "dbo.Modifiers", name: "IX_Talent_Id", newName: "IX_Talent_Id2");
            //RenameIndex(table: "dbo.Modifiers", name: "__mig_tmp__0", newName: "IX_Talent_Id");
            //RenameColumn(table: "dbo.Modifiers", name: "Talent_Id2", newName: "__mig_tmp__0");
            //RenameColumn(table: "dbo.Modifiers", name: "Talent_Id", newName: "Talent_Id2");
            //RenameColumn(table: "dbo.Modifiers", name: "__mig_tmp__0", newName: "Talent_Id");
        }
    }
}
