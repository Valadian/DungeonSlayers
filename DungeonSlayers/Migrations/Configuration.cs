namespace DungeonSlayers.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<DungeonSlayers.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DungeonSlayers.Models.ApplicationDbContext context)
        {
            RacialAbility Gift, Fleet, Night, Immort, Dark, Long, Tough;
            #region Seed RacialAbilities
            context.RacialAbilities.AddOrUpdate(p => p.Name,
                new RacialAbility { Name = "Allergic to Metal -2RP", Value = -2 },
                new RacialAbility { Name = "Arrogant -1RP", Value = -1 },
                Dark = new RacialAbility { Name = "Darkvision +1RP", Value = 1 },
                new RacialAbility { Name = "Monocular -1RP", Value = -1 },
                new RacialAbility { Name = "Fragile -1RP", Value = -1 },
                new RacialAbility { Name = "Quick +1RP", Value = 1 },
                new RacialAbility { Name = "Gold Lust -1RP", Value = -1 },
                new RacialAbility { Name = "Large +4RP", Value = 4 },
                new RacialAbility { Name = "Small -4RP", Value = -4 },
                Long = new RacialAbility { Name = "Longevity +0RP", Value = 0 },
                Fleet = new RacialAbility { Name = "Fleet Footed +1RP", Value = 1 },
                new RacialAbility { Name = "Light Sensitivity -1RP", Value = -1 },
                new RacialAbility { Name = "Magic Resistance -1RP", Value = -1 },
                new RacialAbility { Name = "Magically Gifted +1RP", Value = 1 },
                new RacialAbility { Name = "Magically Impotent -1RP", Value = -1 },
                Night = new RacialAbility { Name = "Night Vision +1RP", Value = 1 },
                new RacialAbility { Name = "Fast +1RP", Value = 1 },
                Gift = new RacialAbility { Name = "Gifted +2RP", Value = 2 },
                new RacialAbility { Name = "Clumsy -2RP", Value = -2 },
                new RacialAbility { Name = "Unkempt -1RP", Value = -1 },
                Immort = new RacialAbility { Name = "Immortal +0RP", Value = 0 },
                new RacialAbility { Name = "Incompetent -4RP", Value = -4 },
                new RacialAbility { Name = "Despised -1RP", Value = -1 },
                Tough = new RacialAbility { Name = "Tough +1RP", Value = 1 },
                new RacialAbility { Name = "More than meets the eye +3RP", Value = 3 },
                new RacialAbility { Name = "Sure Shot +1RP", Value = 1 },
                new RacialAbility { Name = "Slow -1RP", Value = -1 }
            );
            #endregion
            #region Seed Races
            context.DefaultRaces.AddOrUpdate(p => p.Name,
                new Race { Name = "Human",
                    RacialAbilities = new List<RacialAbility>() {
                        Gift
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Gifted")).First(),
                    }
                },
                new Race { Name = "Elf",
                    RacialAbilities = new List<RacialAbility>() {
                        Fleet, Night, Immort
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Fleet")).First(),
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Night")).First(),
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Immortal")).First(),
                    }
                },
                new Race { Name = "Dwarf",
                    RacialAbilities = new List<RacialAbility>() {
                        Dark, Long, Tough
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Dark")).First(),
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Longevity")).First(),
                        //context.RacialAbilities.Where(ra => ra.Name.StartsWith("Tough")).First(),
                    }
                }
            );
            #endregion
            #region Seed Classes
            context.Classes.AddOrUpdate(p => p.Name,
                new BaseClass
                {
                    Name = "Fighter",
                    HeroClasses = new List<HeroClass>()
                    {
                        new HeroClass {Name =  "Berserker"},
                        new HeroClass { Name = "Paladin" },
                        new HeroClass { Name = "Weapon Master" },
                    }
                },
                new BaseClass
                {
                    Name = "Scout",
                    HeroClasses = new List<HeroClass>()
                    {
                        new HeroClass {Name =  "Assassin"},
                        new HeroClass { Name = "Ranger" },
                        new HeroClass { Name = "Rogue" },
                    }
                },
                new BaseClass
                {
                    Name = "Healer",
                    HeroClasses = new List<HeroClass>()
                    {
                        new HeroClass {Name =  "Cleric"},
                        new HeroClass { Name = "Druid" },
                        new HeroClass { Name = "Monk" },
                    }
                },
                new BaseClass
                {
                    Name = "Wizard",
                    HeroClasses = new List<HeroClass>()
                    {
                        new HeroClass {Name =  "Archmage"},
                        new HeroClass { Name = "Battle Mage" },
                        new HeroClass { Name = "Elementalist" },
                    }
                },
                new BaseClass
                {
                    Name = "Sorcerer",
                    HeroClasses = new List<HeroClass>()
                    {
                        new HeroClass {Name =  "Blood Mage"},
                        new HeroClass { Name = "Demonologist" },
                        new HeroClass { Name = "Necromancer" },
                    }
                }
            );
            #endregion
            #region Seed Properties
            context.PropertyDefs.AddOrUpdate(p => p.Name,
                new PropertyDef { Name = PropertyName.Body, PropType = PropertyType.Attribute, Acronym = "BOD", DisplayName = "Body" },
                new PropertyDef { Name = PropertyName.Mobility, PropType = PropertyType.Attribute, Acronym = "MOB", DisplayName = "Mobility" },
                new PropertyDef { Name = PropertyName.Mind, PropType = PropertyType.Attribute, Acronym = "MND", DisplayName = "Mind" },

                new PropertyDef { Name = PropertyName.Strength, PropType = PropertyType.Trait, Acronym = "ST", DisplayName = "Strength" },
                new PropertyDef { Name = PropertyName.Constitution, PropType = PropertyType.Trait, Acronym = "CO", DisplayName = "Constitution" },
                new PropertyDef { Name = PropertyName.Dexterity, PropType = PropertyType.Trait, Acronym = "AG", DisplayName = "Dexterity" },
                new PropertyDef { Name = PropertyName.Agility, PropType = PropertyType.Trait, Acronym = "DX", DisplayName = "Agility" },
                new PropertyDef { Name = PropertyName.Intellect, PropType = PropertyType.Trait, Acronym = "IN", DisplayName = "Intellect" },
                new PropertyDef { Name = PropertyName.Aura, PropType = PropertyType.Trait, Acronym = "AU", DisplayName = "Aura" },

                                //new PropertyDef { Name = PropertyName.HitPoints, PropType = PropertyType.CombatValue, Acronym = "HP", DisplayName = "Hit Points", Derived = true, Equation = "@BOD +@CO+10", DataBinding = "+Body() + +Constitution() + 10" },
                                //new PropertyDef { Name = PropertyName.Defense, PropType = PropertyType.CombatValue, Acronym = "DEF", DisplayName = "Defense", Derived = true, Equation = "@BOD+@CO+@AV", DataBinding = "+Body() + +Constitution() + +ArmorValue()" },
                                //new PropertyDef { Name = PropertyName.Initiative, PropType = PropertyType.CombatValue, Acronym = "INI", DisplayName = "Initiative", Derived = true, Equation = "@MOV+@AG", DataBinding = "+Mobility() + +Agility()" },
                                //new PropertyDef { Name = PropertyName.MovementRate, PropType = PropertyType.CombatValue, Acronym = "MR", DisplayName = "Movement", Derived = true, Equation = "@MOB/2+1", DataBinding = "+Mobility() / 2 + 1" },
                                //new PropertyDef { Name = PropertyName.MeleeAttack, PropType = PropertyType.CombatValue, Acronym = "MAT", DisplayName = "MAT", Derived = true, Equation = "@BOD+@ST+@WB", DataBinding = "+Body() + +Strength() + +WeaponBonus()" },
                                //new PropertyDef { Name = PropertyName.RangedAttack, PropType = PropertyType.CombatValue, Acronym = "RAT", DisplayName = "RAT", Derived = true, Equation = "@MOB+@DX+@WB", DataBinding = "+Mobility() + +Dexterity() + +WeaponBonus()" },
                                //new PropertyDef { Name = PropertyName.Spellcasting, PropType = PropertyType.CombatValue, Acronym = "SPC", DisplayName = "SPC", Derived = true, Equation = "@MND+@AU-@AV+@SM", DataBinding = "+Mind() + +Aura() - +ArmorValue() + +SpellModifier()" },
                                //new PropertyDef { Name = PropertyName.TargetedSpellcasting, PropType = PropertyType.CombatValue, Acronym = "TSC", DisplayName = "TSC", Derived = true, Equation = "@MND+@DX-@AV+@SM", DataBinding = "+Mind() + +Dexterity() - +ArmorValue() + +SpellModifier()" },

                                new PropertyDef { Name = PropertyName.HitPoints, PropType = PropertyType.CombatValue, Acronym = "HP", DisplayName = "Hit Points", Derived = true, Equation = "@BOD +@CO+10", DataBinding = "+Model.BOD() + +Model.CO() + 10" },
                new PropertyDef { Name = PropertyName.Defense, PropType = PropertyType.CombatValue, Acronym = "DEF", DisplayName = "Defense", Derived = true, Equation = "@BOD+@CO+@AV", DataBinding = "+Model.BOD() + +Model.CO() + +Model.AV()" },
                new PropertyDef { Name = PropertyName.Initiative, PropType = PropertyType.CombatValue, Acronym = "INI", DisplayName = "Initiative", Derived = true, Equation = "@MOB+@AG", DataBinding = "+Model.MOB() + +Model.AG()" },
                new PropertyDef { Name = PropertyName.MovementRate, PropType = PropertyType.CombatValue, Acronym = "MR", DisplayName = "Movement", Derived = true, Equation = "@MOB/2+1", DataBinding = "+Model.MOB() / 2 + 1" },
                new PropertyDef { Name = PropertyName.MeleeAttack, PropType = PropertyType.CombatValue, Acronym = "MAT", DisplayName = "MAT", Derived = true, Equation = "@BOD+@ST+@WB", DataBinding = "+Model.BOD() + +Model.ST() + +Model.WB()" },
                new PropertyDef { Name = PropertyName.RangedAttack, PropType = PropertyType.CombatValue, Acronym = "RAT", DisplayName = "RAT", Derived = true, Equation = "@MOB+@DX+@WB", DataBinding = "+Model.MOB() + +Model.DX() + +Model.WB()" },
                new PropertyDef { Name = PropertyName.Spellcasting, PropType = PropertyType.CombatValue, Acronym = "SPC", DisplayName = "SPC", Derived = true, Equation = "@MND+@AU-@AV+@SM", DataBinding = "+Model.MND() + +Model.AU() - +Model.AV() + +Model.SM()" },
                new PropertyDef { Name = PropertyName.TargetedSpellcasting, PropType = PropertyType.CombatValue, Acronym = "TSC", DisplayName = "TSC", Derived = true, Equation = "@MND+@DX-@AV+@SM", DataBinding = "+Model.MND() + +Model.DX() - +Model.AV() + +Model.SM()" },

                new PropertyDef { Name = PropertyName.ArmorValue, PropType = PropertyType.Misc, Acronym = "AV", DisplayName = "SUM AV" },
                new PropertyDef { Name = PropertyName.WeaponBonus, PropType = PropertyType.Misc, Acronym = "WB", DisplayName = "WB" },
                new PropertyDef { Name = PropertyName.SpellModifier, PropType = PropertyType.Misc, Acronym = "SM", DisplayName = "SM" }
            );
            #endregion
            #region Seed Weapons
            context.Weapons.AddOrUpdate(p => p.Name,
                new Weapon { Name = "Axes", TwoHanded = true, WeaponBonus = 3, Effect = "INI -2", Availability = Availability.Hamlets, Price = 7 },
                new Weapon { Name = "Battle Flail", WeaponBonus = 3, Effect = "INI -4, OpDef -4", Availability = Availability.Villages, Price = 16, HitsSelfFumble = true },
                new Weapon { Name = "Bow, elven", Ranged = true, Melee = false, TwoHanded = true, WeaponBonus = 3, Effect = "INI +1", Availability = Availability.Elven, Price = 75, Unwieldy = true },
                new Weapon { Name = "Bow, long", Ranged = true, Melee = false, TwoHanded = true, WeaponBonus = 2, Effect = "INI +1", Availability = Availability.Villages, Price = 10, Unwieldy = true },
                new Weapon { Name = "Bow, short", Ranged = true, Melee = false, TwoHanded = true, WeaponBonus = 1, Effect = "INI +1", Availability = Availability.Hamlets, Price = 6 },
                new Weapon { Name = "Brass Knuckles", WeaponBonus = 0, Availability = Availability.Villages, Price = 1 },
                new Weapon { Name = "Club", WeaponBonus = 1, Availability = Availability.Hamlets, Price = 0.2, BreakMATFumble = true },
                new Weapon { Name = "Crossbow, heavy", Ranged = true, Melee = false, TwoHanded = true, WeaponBonus = 3, Effect = "INI -4, OpDef -2", Availability = Availability.Villages, Price = 15 },
                new Weapon { Name = "Crossbow, light", Ranged = true, Melee = false, TwoHanded = true, WeaponBonus = 2, Effect = "INI -2", Availability = Availability.Hamlets, Price = 8 },
                new Weapon { Name = "Dagger", WeaponBonus = 0, Effect = "INI +1", Availability = Availability.Hamlets, Price = 2 },
                new Weapon { Name = "Dwarven Axe", TwoHanded = true, WeaponBonus = 3, Effect = "INI -1, OpDef -2", Availability = Availability.Dwarven, Price = 60 },
                new Weapon { Name = "Flail", WeaponBonus = 2, Effect = "INI -2", Availability = Availability.Hamlets, Price = 8 },
                new Weapon { Name = "Great Axe", TwoHanded = true, WeaponBonus = 4, Effect = "INI -6, OpDef -4", Availability = Availability.Cities, Price = 20, Unwieldy = true },
                new Weapon { Name = "Halberd", TwoHanded = true, WeaponBonus = 2, Effect = "@INI -2", Availability = Availability.Villages, Price = 4, BreakMATFumble = true },
                new Weapon { Name = "Hammer", WeaponBonus = 1, Effect = "OpDef -1", Availability = Availability.Hamlets, Price = 7 },
                new Weapon { Name = "Hatchet", WeaponBonus = 1, Availability = Availability.Hamlets, Price = 6 },
                new Weapon { Name = "Lance", WeaponBonus = 1, Effect = "IF gallop WB=+4", Availability = Availability.Villages, Price = 2 },
                new Weapon { Name = "Mace/Morningstar", WeaponBonus = 1, Effect = "OpDef -1", Availability = Availability.Hamlets, Price = 7 },
                new Weapon { Name = "Quarterstaff", TwoHanded = true, WeaponBonus = 1, Effect = "TSC +1", Availability = Availability.Hamlets, Price = 0.5 },
                new Weapon { Name = "Sling", Ranged = true, Melee = false, WeaponBonus = 0, Effect = "DistMod -1 per 2m", Availability = Availability.Hamlets, Price = 0.1 },
                new Weapon { Name = "Spear", Ranged = true, Melee = true, WeaponBonus = 1, Effect = "Melee or Ranged", Availability = Availability.Hamlets, Price = 1, BreakRATFumble = true },
                new Weapon { Name = "Sword, broad", WeaponBonus = 1, Effect = "OpDef -2", Availability = Availability.Hamlets, Price = 8 },
                new Weapon { Name = "Sword, long", WeaponBonus = 2, Availability = Availability.Hamlets, Price = 7 },
                new Weapon { Name = "Sword, short", WeaponBonus = 1, Availability = Availability.Hamlets, Price = 6 },
                new Weapon { Name = "Throwing Knife", Ranged = true, Melee = true, WeaponBonus = 0, Effect = "Melee or Ranged, DistMode -1 per 2m", Availability = Availability.Hamlets, Price = 2 },
                new Weapon { Name = "Two-handed Sword", TwoHanded = true, WeaponBonus = 3, Effect = "INI -2, OpDef -4", Availability = Availability.Hamlets, Price = 10 },
                new Weapon { Name = "Uarmed", WeaponBonus = 0, Effect = "OpDef -4" },
                new Weapon { Name = "War Hammer", TwoHanded = true, WeaponBonus = 3, Availability = Availability.Hamlets, Price = 6 }
            );
            #endregion
            #region
            context.Armors.AddOrUpdate(c => c.Name,
                new Armor { Name = "Chainmail", AV = 2, Effect = "MR -0.5", Availability = Availability.Villages, Price = 10 },
                new Armor { Name = "Leather Armor", AV = 1, Availability = Availability.Hamlets, Price = 4 },
                new Armor { Name = "Leather Vambraces & Greaves", AV = 1, Availability = Availability.Hamlets, Price = 4 },
                new Armor { Name = "Metal Helmet", AV = 1, Effect = "INI -1", Availability = Availability.Hamlets, Price = 6 },
                new Armor { Name = "Plate Greaves", AV = 1, Effect = "MR -0.5", Availability = Availability.Villages, Price = 8 },
                new Armor { Name = "Plate Vambrace", AV = 1, Effect = "MR -0.5", Availability = Availability.Villages, Price = 7 },
                new Armor { Name = "Plate Armor", AV = 3, Effect = "MR -1", Availability = Availability.Villages, Price = 50 },
                new Armor { Name = "Mount Plate Armor", AV = 3, Effect = "MR -1", Availability = Availability.Villages, Price = 150 },
                new Armor { Name = "Robe", AV = 0, Availability = Availability.Hamlets, Price = 1 },
                new Armor { Name = "Runic Robe", AV = 0, Effect = "AU +1", Availability = Availability.Villages, Price = 8 },
                new Armor { Name = "Shield, Metal", AV = 1, Effect = "MR -0.5", Availability = Availability.Hamlets, Price = 8 },
                new Armor { Name = "Shield, Tower", AV = 2, Effect = "MR -1", Availability = Availability.Villages, Price = 15 },
                new Armor { Name = "Shield, Wooden", AV = 1, Availability = Availability.Hamlets, Price = 1, BreakDEFFumble = true }
            );
            #endregion
            #region Seed Checks
            context.Checks.AddOrUpdate(c => c.Name,
                new Check { Name = "Appraise Treasure", DataBinding = "+MND() + +IN()", PrettyBinding = "MND+IN (GM Secret Roll)" },
                new Check { Name = "Climb", DataBinding = "+MOB() + +ST()", PrettyBinding = "MOB+ST per (MOBx2 climb)" },
                new Check { Name = "Communicate", DataBinding = "+MND() + +DX()", PrettyBinding = "MND+DX+#Languages" },
                new Check { Name = "Decipher Script", DataBinding = "+MND() + +IN()", PrettyBinding = "MND+IN" },
                new Check { Name = "Defy Poison", DataBinding = "+BOD() + +CO()", PrettyBinding = "BOD+CO+Endurance" },
                new Check { Name = "Disable Traps", DataBinding = "+MND() + +DX()", PrettyBinding = "MND+DX" },
                new Check { Name = "Feat of Strength", DataBinding = "+BOD() + +ST()", PrettyBinding = "BOD+ST" },
                new Check { Name = "Flirt", DataBinding = "+MND() + +AU()", PrettyBinding = "MND+AU" },
                new Check { Name = "Haggle", DataBinding = "Math.max(+MND() + +IN(), +MND() + +AU())", PrettyBinding = "MND+IN/+AU" },
                new Check { Name = "Hide", DataBinding = "+MOB() + +AG()", PrettyBinding = "MOB+AG" },
                new Check { Name = "Jump", DataBinding = "+MOB() + +AG()", PrettyBinding = "MOB+AG" },
                new Check { Name = "Knowledge", DataBinding = "+MND() + +IN()", PrettyBinding = "MND+IN" },
                new Check { Name = "Open Lock", DataBinding = "+MND() + +DX()", PrettyBinding = "MND+DX" },
                new Check { Name = "Perception", DataBinding = "Math.max(+MND() + +IN(),8)", PrettyBinding = "MND+IN OR 8" },
                new Check { Name = "Performance", DataBinding = "", PrettyBinding = "*" },
                new Check { Name = "Pick Pocket", DataBinding = "+MOB() + +DX()", PrettyBinding = "MOB+DX" },
                new Check { Name = "Read Tracks", DataBinding = "+MND() + +IN()", PrettyBinding = "MND+IN" },
                new Check { Name = "Resist Disease", DataBinding = "+BOD() + +CO()", PrettyBinding = "BOD+CO+Endurance" },
                new Check { Name = "Ride", DataBinding = "Math.max(+MOB() + +AG(),+MOB() + +AU())", PrettyBinding = "MOB+AG/+AU" },
                new Check { Name = "Search", DataBinding = "Math.max(+MND() + +IN(),8)", PrettyBinding = "MND+IN OR 8" },
                new Check { Name = "Sneak", DataBinding = "+MOB() + +AG()", PrettyBinding = "MOB+AG" },
                new Check { Name = "Start Fire", DataBinding = "+MND() + +DX()", PrettyBinding = "MND+DX" },
                new Check { Name = "Swimming", DataBinding = "+MOB() + +DX()", PrettyBinding = "MOB+DX" },
                new Check { Name = "Wake Up", DataBinding = "+MND() + +IN()", PrettyBinding = "MND+IN" },
                new Check { Name = "Work Mechanism", DataBinding = "Math.max(+MND() + +DX(), +MND() + +AU())", PrettyBinding = "MND+DX/+AU" }
                );
            #endregion
            #region Seed Spells
            context.Spells.AddOrUpdate(c => c.Name,
                new Spell { Name = "Arcane Sword",                              HealerLevel = null, WizardLevel = 10, SorcererLevel = 8,    GoldCost = 920, SM = "+0", Duration = "INx2", Distance="IN radius", CooldownPeriod="24 hours",Effect="Autonomous, Light IN m, CV = Mage Lvl + 10, MR = Mage MRx2" },
                new Spell { Name = "Artic Weapon", Targeted = true,             HealerLevel = null, WizardLevel = 4, SorcererLevel = null,  GoldCost = 160, SM = "+0", Duration = "check", Distance = "INx2", CooldownPeriod = "100", Effect = "WB+1, coup = 1 round frozen (Halt), No Stack: Scorching" },
                new Spell { Name = "Arrow of Light", Targeted = true,           HealerLevel = 2,    WizardLevel = 5, SorcererLevel = null,  GoldCost = 45, SM = "+2", Duration = "Instant", Distance = "INx5", CooldownPeriod = "1", Effect = "CreatureOfDark -2 Def against this. Not usable by ServantOfDark" },
                new Spell { Name = "Balance",                                   HealerLevel = 2, WizardLevel = 3, SorcererLevel = 6,        GoldCost = 45, SM = "-2", Duration = "for distance", Distance = "Touch", CooldownPeriod = "10", Effect = "Walk thin rope/narrow walkways, Last for MRx2" },
                new Spell { Name = "Banish",                                    HealerLevel = 8, WizardLevel = 18, SorcererLevel = 14,      GoldCost = 255, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "INx2 radius", CooldownPeriod = "100", Effect = "destroys Lvl/2 random hostile demons/elementals/undead in radius, +2 check per failure" },
                new Spell { Name = "Be Friend", MindInfluencing = true,         HealerLevel = 6, WizardLevel = 7, SorcererLevel = 8,        GoldCost = 370, SM = "+0", TM = "-(MND+IN)/2", Duration = "IN min", Distance = "INx2", CooldownPeriod = "24 hours", Effect = "Tgt close friends with only mage" },
                new Spell { Name = "Bestow Defense",                            HealerLevel = 1, WizardLevel = 4, SorcererLevel = 4,        GoldCost = 10, SM = "+0", Duration = "1", Distance = "INx2", CooldownPeriod = "0", Effect = "Def + Check" },
                new Spell { Name = "Bestow Scent",                              HealerLevel = 1, WizardLevel = 1, SorcererLevel = 2,        GoldCost = 10, SM = "+0", Duration = "check min", Distance = "Touch", CooldownPeriod = "100", Effect = "+/- 2 social interactions" },
                new Spell { Name = "Blessing",                                  HealerLevel = 2, WizardLevel = null, SorcererLevel = null,  GoldCost = 90, SM = "+0", Duration = "IN hours", Distance = "Self", CooldownPeriod = "24 hours", Effect = "Mage + INx2 party members in INx2 meters: +1 all checks" },
                new Spell { Name = "Blind", Targeted = true,                    HealerLevel = 1, WizardLevel = 5, SorcererLevel = null,     GoldCost = 10, SM = "+0", TM = "-(MOB+AU)/2", Duration = "check", Distance = "INx5", CooldownPeriod = "5", Effect = "-8 all checks requiring eyesight. Eyeless undead not immune, naturally blind immune" },
                new Spell { Name = "Body Explosion", Targeted = true,           HealerLevel = null, WizardLevel = null, SorcererLevel = 20, GoldCost = 3735, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "IN", CooldownPeriod = "D20 days", Effect = "Damage = check x4, Tgt Def no armor, incorporeal immune" },
                new Spell { Name = "Boil Blood", Targeted = true,               HealerLevel = null, WizardLevel = 17, SorcererLevel = 13,   GoldCost = 1580, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "IN", CooldownPeriod = "24 hours", Effect = "Damage = check x2, Tgt Def no armor, bloodless immune" },
                new Spell { Name = "Breach",                                    HealerLevel = null, WizardLevel = 6, SorcererLevel = 14,    GoldCost = 260, SM = "+0", Duration = "Check/2", Distance = "Touch", CooldownPeriod = "100", Effect = "1m diameter hole, INx0.1 thickness. hole disappears after" },
                new Spell { Name = "Burning Faith",                             HealerLevel = 6, WizardLevel = null, SorcererLevel = null,  GoldCost = 185, SM = "-2", Duration = "Check", Distance = "Touch", CooldownPeriod = "100", Effect = "WB+IN/2, Tgt Def-IN/2" },
                new Spell { Name = "Burning Inferno", Targeted = true,          HealerLevel = null, WizardLevel = 15, SorcererLevel = 15,   GoldCost = 1420, SM = "+5", Duration = "IN", Distance = "INx10", CooldownPeriod = "24 hours", Effect = "IN m radius circle of undefendable damage = check, per round" },
                new Spell { Name = "Call Shades",                               HealerLevel = null, WizardLevel = null, SorcererLevel = 13, GoldCost = 1580, SM = "+0", Duration = "Instant", Distance = "INx5 radius", CooldownPeriod = "24 hours", Effect = "Creates up to LVL shades from dead after 3 rounds that attack caster. Not usable by ServantOfLight" },
                new Spell { Name = "Calm Animal",                               HealerLevel = 1, WizardLevel = 7, SorcererLevel = null,     GoldCost = 20, SM = "+0", TM = "-HP/5", Duration = "IN hours", Distance = "INx5 radius", CooldownPeriod = "24 hours", Effect = "Calms aggressive animals. Magical and Dominated animals immune" },
                new Spell { Name = "Cantrip",                                   HealerLevel = null, WizardLevel = 1, SorcererLevel = 1,     GoldCost = 10, SM = "+0", Duration = "Check", Distance = "INx2", CooldownPeriod = "10", Effect = "small harmless illusions"},
                new Spell { Name = "Chain Lightning", Targeted = true,          HealerLevel = 16, WizardLevel = 10, SorcererLevel = 10,     GoldCost = 460, SM = "+3", Duration = "Instant", Distance = "INx5", CooldownPeriod = "5", Effect = "hits IN more targets, 2m gap, Metal armor = No defense" },
                new Spell { Name = "Change Race",                               HealerLevel = null, WizardLevel = 5, SorcererLevel = 5,     GoldCost = 420, SM = "-4", Duration = "Check hours", Distance = "IN", CooldownPeriod = "24 hours", Effect = "IN # consenting -> humanoid race of same size." },
                new Spell { Name = "Chasm",                                     HealerLevel = 10, WizardLevel = 10, SorcererLevel = 14,     GoldCost = 325, SM = "-4", Duration = "IN", Distance = "INx2", CooldownPeriod = "100", Effect = "IN m wide, IN/2 m depth/length, Jump check to avoid, on closing: 2D20 undefendable damage" },
                new Spell { Name = "Cleanse",                                   HealerLevel = 3, WizardLevel = 7, SorcererLevel = null,     GoldCost = 80, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "0", Effect = "cleans object, purifies meal" },
                new Spell { Name = "Cloud of Death",                            HealerLevel = null, WizardLevel = null, SorcererLevel = 13, GoldCost = 790, SM = "-4", Duration = "Check x2", Distance = "INx5", CooldownPeriod = "100", Effect = "IN radius, -2 checks, 1+ServantOfDarkness damage per round" },
                new Spell { Name = "Cloud of Remorse",                          HealerLevel = 1, WizardLevel = 6, SorcererLevel = null,     GoldCost = 10, SM = "-2", Duration = "Check", Distance = "INx5", CooldownPeriod = "100", Effect = "IN radius, -1 all checks" },
                new Spell { Name = "Concealing Fog",                            HealerLevel = null, WizardLevel = 4, SorcererLevel = 3,     GoldCost = 140, SM = "-2", Duration = "INx2", Distance = "INx5", CooldownPeriod = "10", Effect = "IN radius, -8 attacks, -8 checks requiring eyesight" },
                new Spell { Name = "Confusion", MindInfluencing = true,         HealerLevel = 8, WizardLevel = 5, SorcererLevel = 5,        GoldCost = 210, SM = "+0", TM = "-(MND+AU)/2", Duration = "Check", Distance = "INx2 radius", CooldownPeriod = "10", Effect = "random actions: 1-5 att op, 6-10 random move, 11-15 still, 16+ attack ally" },
                new Spell { Name = "Consecrate Water",                          HealerLevel = 1, WizardLevel = null, SorcererLevel = null,  GoldCost = 10, SM = "+0", Duration = "IN hours", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "check x 0.5 L water to holy water (D20 damage undead)" },
                new Spell { Name = "Create Food",                               HealerLevel = 2, WizardLevel = 7, SorcererLevel = null,     GoldCost = 90, SM = "+0", Duration = "Instant", Distance = "IN", CooldownPeriod = "24 hours", Effect = "creates ingredients for LVL meals" },
                new Spell { Name = "Create Web", Targeted = true,               HealerLevel = 4, WizardLevel = 9, SorcererLevel = 9,        GoldCost = 115, SM = "+0", TM = "-(MOB+AU)/2", Duration = "Check/2", Distance = "INx5", CooldownPeriod = "10", Effect = "IN/2 radius, (INI,MR,MAT)/2, +2 size immune" },
                new Spell { Name = "Curse",                                     HealerLevel = null, WizardLevel = 6, SorcererLevel = 2,     GoldCost = 150, SM = "+0", TM = "-(MND+AU)/2", Duration = "Check days", Distance = "touch", CooldownPeriod = "24 hours", Effect = "need something from target, -2 all checks (stackable)" },
                new Spell { Name = "Dance", Targeted = true,                    HealerLevel = null, WizardLevel = 8, SorcererLevel = 10,    GoldCost = 360, SM = "+0", TM = "-(MND+AU)/2", Duration = "IN/2", Distance = "INx5", CooldownPeriod = "10", Effect = "Tgt dances. MR=1. ends on damage" },
                new Spell { Name = "Defensive Shield",                          HealerLevel = 4, WizardLevel = 8, SorcererLevel = 8,        GoldCost = 115, SM = "+0", Duration = "Check", Distance = "Touch", CooldownPeriod = "100", Effect = "Def + Check" },
                new Spell { Name = "Dementia",                                  HealerLevel = null, WizardLevel = null, SorcererLevel = 15, GoldCost = 2850, SM = "+0", TM = "-(MND+AU)/2", Duration = "Instant", Distance = "Touch", CooldownPeriod = "D20 days", Effect = "insane, MND = 0, +1 MND restored per Restoration " },
                new Spell { Name = "Destroy Magics",                            HealerLevel = 12, WizardLevel = 7, SorcererLevel = 12,      GoldCost = 620, SM = "+0", Duration = "Instant", Distance = "IN", CooldownPeriod = "24 hours", Effect = "check=-LVL of EnemyMage to dispel spells, check=-HP/2 of Magical creature: check x2 damage. Failure targets self" },
                new Spell { Name = "Detect Magic",                              HealerLevel = 1, WizardLevel = 1, SorcererLevel = 1,        GoldCost = 10, SM = "+0", Duration = "Check", Distance = "INx2 radius", CooldownPeriod = "10", Effect = "visually reveals magic in area" },
                new Spell { Name = "Dirt",                                      HealerLevel = null, WizardLevel = 5, SorcererLevel = 5,     GoldCost = 420, SM = "+0", Duration = "IN/2 hours", Distance = "INx2", CooldownPeriod = "24 hours", Effect = "magical servant that ONLY cleans" },
                new Spell { Name = "Displace",                                  HealerLevel = 10, WizardLevel = 6, SorcererLevel = 6,       GoldCost = 260, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "10", Effect = "consenting teleported check/2 m straight unobstructed line" },
                new Spell { Name = "Dominate", MindInfluencing = true,          HealerLevel = null, WizardLevel = 12, SorcererLevel = 10,   GoldCost = 1120, SM = "+0", TM = "-(MND+IN)/2", Duration = "IN/2", Distance = "INx2", CooldownPeriod = "24 hours", Effect = "slave except suicide or self mutilation" },
                new Spell { Name = "Dominate Animal", MindInfluencing = true,   HealerLevel = null, WizardLevel = 9, SorcererLevel = 8,     GoldCost = 410, SM = "+0", TM = "-HP/2", Duration = "IN hours", Distance = "INx2", CooldownPeriod = "100", Effect = "slave, obeys monosullabic commands, up to IN # " },
                new Spell { Name = "Dominate Undead",                           HealerLevel = null, WizardLevel = 8, SorcererLevel = 4,     GoldCost = 205, SM = "+0", TM = "-(MND+AU)/2", Duration = "inf", Distance = "INx2", CooldownPeriod = "10", Effect = "LVL # random slaves, die on mage death" },
                new Spell { Name = "Eavesdrop",                                 HealerLevel = 6, WizardLevel = 2, SorcererLevel = 2,        GoldCost = 75, SM = "+0", Duration = "INx2", Distance = "self", CooldownPeriod = "100", Effect = "check=-1 per 10m, center of hearing INx5 along line of sight" },
                new Spell { Name = "Embiggen",                                  HealerLevel = null, WizardLevel = 10, SorcererLevel = 12,   GoldCost = 920, SM = "-4", Duration = "check/2", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "consenting size,equipment,BOD,ST,CONx2" },
                new Spell { Name = "Enchant Weapon",                            HealerLevel = 1, WizardLevel = 1, SorcererLevel = 1,        GoldCost = 10, SM = "+0", Duration = "IN min", Distance = "Touch", CooldownPeriod = "1", Effect = "WB+1" },
                new Spell { Name = "Ethereal Form",                             HealerLevel = null, WizardLevel = 15, SorcererLevel = 18,   GoldCost = 1420, SM = "+0", Duration = "check x5", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "gaseous, MRx4, no cast/talk/attack/move through, cancel as free action" },
                new Spell { Name = "Eyes and Ears",                             HealerLevel = 8, WizardLevel = 6, SorcererLevel = 4,        GoldCost = 205, SM = "+0", Duration = "INx2", Distance = "Self", CooldownPeriod = "100", Effect = "detaches from mody, MR=IN" },
                new Spell { Name = "Feather Fall",                              HealerLevel = 5, WizardLevel = 3, SorcererLevel = 3,        GoldCost = 110, SM = "+0", Duration = "1 min", Distance = "Touch", CooldownPeriod = "0", Effect = "Tgt can activate up to 1 min later, fall 1m/round up to check x2" },
                new Spell { Name = "Fire Beam", Targeted = true,                HealerLevel = null, WizardLevel = 1, SorcererLevel = 1,     GoldCost = 10, SM = "+1", Duration = "Instant", Distance = "INx5", CooldownPeriod = "0", Effect = "check = Damage" },
                new Spell { Name = "Fire Breath", Targeted = true,              HealerLevel = null, WizardLevel = 10, SorcererLevel = 10,   GoldCost = 460, SM = "+3", Duration = "Instant", Distance = "IN", CooldownPeriod = "10", Effect = "1m diameter, check = undefendable damage" },
                new Spell { Name = "Fire Lance", Targeted = true,               HealerLevel = null, WizardLevel = 5, SorcererLevel = 5,     GoldCost = 210, SM = "+2", Duration = "Instant", Distance = "INx10", CooldownPeriod = "0", Effect = "check = Damage" },
                new Spell { Name = "Fire Wall",                                 HealerLevel = null, WizardLevel = 8, SorcererLevel = 10,    GoldCost = 360, SM = "-2", Duration = "IN", Distance = "INx2", CooldownPeriod = "100", Effect = "1m x IN m x IN m. 2D20 defendable damage" },
                new Spell { Name = "Fireball", Targeted = true,                 HealerLevel = null, WizardLevel = 10, SorcererLevel = 10,   GoldCost = 460, SM = "+3", Duration = "Instant", Distance = "INx10", CooldownPeriod = "10", Effect = "INx2 diameter explosion, check = undefendable damage" },
                new Spell { Name = "Flicker",                                   HealerLevel = 2, WizardLevel = 4, SorcererLevel = 4,        GoldCost = 45, SM = "-2", Duration = "Check x2", Distance = "Self", CooldownPeriod = "100", Effect = "Def +MND/2 except AoE" },
                new Spell { Name = "Fly",                                       HealerLevel = 20, WizardLevel = 10, SorcererLevel = 10,     GoldCost = 460, SM = "+0", Duration = "Check x5", Distance = "Touch", CooldownPeriod = "100", Effect = "1m diameter, check = undefendable damage" },
                new Spell { Name = "Forceful Prayer",                           HealerLevel = 5, WizardLevel = null, SorcererLevel = null,  GoldCost = 150, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "Self", CooldownPeriod = "100", Effect = "LVLx2 m radius, knocksdown opponents" },
                new Spell { Name = "Frighten", MindInfluencing = true,          HealerLevel = 2, WizardLevel = 6, SorcererLevel = 4,        GoldCost = 45, SM = "+0", TM = "-(MND+IN)/2", Duration = "IN", Distance = "INx2 radius", CooldownPeriod = "100", Effect = "LVL # flee. ended by damage" },
                new Spell { Name = "Give To Take",                              HealerLevel = 4, WizardLevel = null, SorcererLevel = null,  GoldCost = 115, SM = "+0", Duration = "check", Distance = "Touch", CooldownPeriod = "5", Effect = "lifesteal damage/2" },
                new Spell { Name = "Guardian",                                  HealerLevel = 4, WizardLevel = 6, SorcererLevel = 5,        GoldCost = 115, SM = "+0", Duration = "IN hours", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "alerts of new beings within INx2 radius" },
                new Spell { Name = "Healberries",                               HealerLevel = 1, WizardLevel = 10, SorcererLevel = null,    GoldCost = 20, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "converts check (Druids: check x2) berries/nuts/tastyLeaves to heal 1HP. Eat 10 in 1 action. Fades after IN days." },
                new Spell { Name = "Healing Aura",                              HealerLevel = 1, WizardLevel = null, SorcererLevel = null,  GoldCost = 10, SM = "+0", Duration = "Check x2", Distance = "Self", CooldownPeriod = "100", Effect = "IN radius, 1HP per round" },
                new Spell { Name = "Healing Light", Targeted = true,            HealerLevel = 4, WizardLevel = null, SorcererLevel = null,  GoldCost = 115, SM = "+2", Duration = "Instant", Distance = "INx2", CooldownPeriod = "2", Effect = "check = healing" },
                new Spell { Name = "Healing Ray", Targeted = true,              HealerLevel = 12, WizardLevel = null, SorcererLevel = null, GoldCost = 395, SM = "+0", Duration = "Instant", Distance = "INx2", CooldownPeriod = "2", Effect = "IN/2 allies, check = healing" },
                new Spell { Name = "Healing Sphere", Targeted = true,           HealerLevel = 18, WizardLevel = null, SorcererLevel = null, GoldCost = 1210, SM = "+2", Duration = "Instant", Distance = "INx2 radius", CooldownPeriod = "24 hours", Effect = "all allies, check = healing" },
                new Spell { Name = "Healing Touch",                             HealerLevel = 1, WizardLevel = null, SorcererLevel = null,  GoldCost = 10, SM = "+1", Duration = "Instant", Distance = "Touch", CooldownPeriod = "0", Effect = "check = healing" },
                new Spell { Name = "Holy Hammer",                               HealerLevel = 10, WizardLevel = null, SorcererLevel = null, GoldCost = 1325, SM = "+0", Duration = "IN", Distance = "INx2 radius", CooldownPeriod = "100", Effect = "appears within IN m, autonomous, CV = LVL+8, MR=MRx2" },
                new Spell { Name = "Hurl", Targeted = true,                     HealerLevel = 16, WizardLevel = 12, SorcererLevel = 10,     GoldCost = 535, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "INx2", CooldownPeriod = "10", Effect = "throws Tgt check/3 m, takes falling damage for distance, prone after" },
                new Spell { Name = "Ice Beam", Targeted = true,                 HealerLevel = null, WizardLevel = 12, SorcererLevel = 16,   GoldCost = 560, SM = "+3", Duration = "Instant", Distance = "INx10", CooldownPeriod = "10", Effect = "check = undefendable damage. frozen IN rounds. end on damage" },
                new Spell { Name = "Identify Magic",                            HealerLevel = 5, WizardLevel = 1, SorcererLevel = 1,        GoldCost = 10, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "1", Effect = "reveals source/function of magic" },
                new Spell { Name = "Invigorate",                                HealerLevel = 4, WizardLevel = 8, SorcererLevel = 8,        GoldCost = 230, SM = "+0", Duration = "Instant", Distance = "Self", CooldownPeriod = "24 hours", Effect = "HP += check. buffer cannot be healed" },
                new Spell { Name = "Invisibility",                              HealerLevel = 20, WizardLevel = 12, SorcererLevel = 12,     GoldCost = 1120, SM = "+0", Duration = "check min", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "Tgt+equipment invisible. end on attack/spell/damage" },
                new Spell { Name = "Jump",                                      HealerLevel = 5, WizardLevel = 2, SorcererLevel = 3,        GoldCost = 60, SM = "+0", Duration = "Instant", Distance = "Self", CooldownPeriod = "10", Effect = "extends Jump by check/2 m" },
                new Spell { Name = "Lance of Light", Targeted=true,             HealerLevel = 10, WizardLevel = 12, SorcererLevel = null,   GoldCost = 325, SM = "+5", Duration = "Instant", Distance = "INx5", CooldownPeriod = "1", Effect = "CreatureOfDark -2 Def against this. Not usable by ServantOfDark" },
                new Spell { Name = "Levitate",                                  HealerLevel = 7, WizardLevel = 5, SorcererLevel = 5,        GoldCost = 210, SM = "+0", Duration = "check", Distance = "Touch", CooldownPeriod = "0", Effect = "Creative Flight. Cannot run" },
                new Spell { Name = "Light",                                     HealerLevel = 1, WizardLevel = 1, SorcererLevel = 5,        GoldCost = 10, SM = "+5", Duration = "check min", Distance = "Touch", CooldownPeriod = "10", Effect = "item bright as torch" },
                new Spell { Name = "Lightning Bolt", Targeted = true,           HealerLevel = 10, WizardLevel = 7, SorcererLevel = 7,       GoldCost = 310, SM = "+3", Duration = "Instant", Distance = "INx10", CooldownPeriod = "1", Effect = "Metal armor = no defense" },
                new Spell { Name = "Magic Barrier",                             HealerLevel = 14, WizardLevel = 10, SorcererLevel = 12,     GoldCost = 920, SM = "-2", Duration = "IN min OR concentration", Distance = "INx2", CooldownPeriod = "24 hours", Effect = "Immobile IN/2 cube that blocks all magic" },
                new Spell { Name = "Magic Ladder",                              HealerLevel = 8, WizardLevel = 4, SorcererLevel = 4,        GoldCost = 320, SM = "+0", Duration = "Concentration", Distance = "IN", CooldownPeriod = "24 hours", Effect = "INxLVL, no support required, mage can climb" },
                new Spell { Name = "Magic Lock",                                HealerLevel = 3, WizardLevel = 1, SorcererLevel = 1,        GoldCost = 10, SM = "+0", Duration = "inf", Distance = "Touch", CooldownPeriod = "5", Effect = "to open = check, in addition to lock LV, mage can open no problems" },
                new Spell { Name = "Mana Bread",                                HealerLevel = null, WizardLevel = 5, SorcererLevel = 5,     GoldCost = 420, SM = "+0", Duration = "Instant", Distance = "IN", CooldownPeriod = "24 hours", Effect = "LVL/2 warm bland violet-blue bread loaves (full meal)" },
                new Spell { Name = "Messenger",                                 HealerLevel = 8, WizardLevel = 6, SorcererLevel = 8,        GoldCost = 510, SM = "+0", Duration = "inf", Distance = "INx5 km", CooldownPeriod = "24 hours", Effect = "ghostly projection to known, message of INx2 syllables" },
                new Spell { Name = "Mirage", MindInfluencing = true,            HealerLevel = null, WizardLevel = 5, SorcererLevel = 7,     GoldCost = 210, SM = "-2", Duration = "IN/2", Distance = "IN", CooldownPeriod = "100", Effect = "visual, immobile illusion of IN/2 m^3. Perception + check/2 to reveal" },
                new Spell { Name = "Necrologue",                                HealerLevel = null, WizardLevel = null, SorcererLevel = 9,  GoldCost = 1590, SM = "+0", Duration = "IN questions/min", Distance = "Touch", CooldownPeriod = "D20 days", Effect = "ask yes or no questions from ghost" },
                new Spell { Name = "Neutralize Poison",                         HealerLevel = 3, WizardLevel = 6, SorcererLevel = 12,       GoldCost = 80, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "10", Effect = "neutralize natural poison" },
                new Spell { Name = "Open",                                      HealerLevel = 2, WizardLevel = 1, SorcererLevel = 1,        GoldCost = 10, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "10", Effect = "check=-LV, -2 on failure for that lock until level up" },
                new Spell { Name = "Paralyze", Targeted = true,                 HealerLevel = 2, WizardLevel = 6, SorcererLevel = 6,        GoldCost = 45, SM = "+0", TM = "-(BOD+AU)/2", Duration = "IN", Distance = "INx5", CooldownPeriod = "10", Effect = "Can only move eyes, think, change spells/cast (no gestures/silently), breath. end on damage" },
                new Spell { Name = "Part Waters", Targeted = true,              HealerLevel = 12, WizardLevel = null, SorcererLevel = null, GoldCost = 1185, SM = "+0", Duration = "Concentration", Distance = "Touch", CooldownPeriod = "D20 days", Effect = "1m wide path, distance penalty for length. check damage to water elementals" },
                new Spell { Name = "Penetrating Gaze",                          HealerLevel = 7, WizardLevel = 3, SorcererLevel = 3,        GoldCost = 280, SM = "-2", Duration = "IN", Distance = "Self", CooldownPeriod = "24 hours", Effect = "see through IN/2 m of non-magical/non-living objects" },
                new Spell { Name = "Permeate",                                  HealerLevel = null, WizardLevel = 10, SorcererLevel = 12,   GoldCost = 920, SM = "-4", Duration = "IN/2", Distance = "Self", CooldownPeriod = "24 hours", Effect = "move through non-magical/non-living objects" },
                new Spell { Name = "Pillar of Light", Targeted = true,          HealerLevel = 16, WizardLevel = 19, SorcererLevel = null,   GoldCost = 535, SM = "+8", Duration = "Instant", Distance = "INx10", CooldownPeriod = "1", Effect = "check+=Retribution, CreatureOfDark -2 Def against this. Not usable by ServantOfDark" },
                new Spell { Name = "Planar Gate",                               HealerLevel = null, WizardLevel = 18, SorcererLevel = 16,   GoldCost = 2580, SM = "-8", Duration = "IN min", Distance = "IN", CooldownPeriod = "D20 days", Effect = "open portal to another named plane. Allows IN/2 beings to travel" },
                new Spell { Name = "Prepare Swap",                              HealerLevel = 12, WizardLevel = 10, SorcererLevel = 12,     GoldCost = 790, SM = "+0", Duration = "Instant", Distance = "Self", CooldownPeriod = "24 hours", Effect = "prepares spell, can make spell active as free action" },
                new Spell { Name = "Prolong Defensive Shield",                  HealerLevel = 4, WizardLevel = null, SorcererLevel = null,  GoldCost = 230, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "active Defensive shield duration x2" },
                new Spell { Name = "Protective Dome",                           HealerLevel = 8, WizardLevel = 12, SorcererLevel = 12,      GoldCost = 765, SM = "+0", Duration = "Concentration", Distance = "Self", CooldownPeriod = "D20 days", Effect = "IN radius, impassable by physical objects" },
                new Spell { Name = "Raise Skeletons",                           HealerLevel = null, WizardLevel = null, SorcererLevel = 6,  GoldCost = 670, SM = "+0", Duration = "Instant", Distance = "INx5 radius", CooldownPeriod = "24 hours", Effect = "LVL # skeletons after 3 rounds that attacks caster. Not usabled by ServantOfLight" },
                new Spell { Name = "Raise Zombies",                             HealerLevel = null, WizardLevel = null, SorcererLevel = 8,  GoldCost = 930, SM = "+0", Duration = "Instant", Distance = "INx5 radius", CooldownPeriod = "24 hours", Effect = "LVL # dead after 3 rounds that attack caster. Not usable by ServantOfLight" },
                new Spell { Name = "Reset Cooldown",                            HealerLevel = 10, WizardLevel = 5, SorcererLevel = 9,       GoldCost = 650, SM = "+0", Duration = "Instant", Distance = "Self", CooldownPeriod = "24 hours", Effect = "-Spell Access level, CP = 0 of spell cast within last IN rounds (one chance)." },
                new Spell { Name = "Resist Poison",                             HealerLevel = 1, WizardLevel = 2, SorcererLevel = 8,        GoldCost = 10, SM = "+0", Duration = "IN hours", Distance = "Touch", CooldownPeriod = "10", Effect = "+LVL to checks and undefendable poison damage" },
                new Spell { Name = "Restoration",                               HealerLevel = 10, WizardLevel = null, SorcererLevel = null, GoldCost = 650, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "heals all (including severed limbs up to D20 hours old)" },
                new Spell { Name = "Resurrection",                              HealerLevel = 10, WizardLevel = null, SorcererLevel = null, GoldCost = 650, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "within D20 days of unnatural death to 1HP, permanent -1BOD. No Restoration to fix lethal blow" },
                new Spell { Name = "Rout Undead",                               HealerLevel = 1, WizardLevel = null, SorcererLevel = null,  GoldCost = 10, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Check/2 min", Distance = "INx2 radius", CooldownPeriod = "100", Effect = "LVL/2 # random undead flee up to check x5 m, end on damage. coup does damage" },
                new Spell { Name = "Rust", Targeted = true,                     HealerLevel = 5, WizardLevel = 7, SorcererLevel = 8,        GoldCost = 150, SM = "+0", Duration = "Instant", Distance = "INx2", CooldownPeriod = "10", Effect = "check-WB/-AV, non-magical metal weapon/armor to dust" },
                new Spell { Name = "Scorching Blade", Targeted = true,          HealerLevel = null, WizardLevel = 4, SorcererLevel = 4,     GoldCost = 160, SM = "+0", Duration = "Check", Distance = "INx2", CooldownPeriod = "100", Effect = "WB+1, Coup = explosion D20 damage. No Stack: Artic" },
                new Spell { Name = "See Hidden",                                HealerLevel = 8, WizardLevel = 8, SorcererLevel = 8,        GoldCost = 510, SM = "+0", Duration = "Check", Distance = "INx2 radius", CooldownPeriod = "24 hours", Effect = "hidden inanimate nonmagical objects twinkle" },
                new Spell { Name = "See Invisible",                             HealerLevel = 10, WizardLevel = 12, SorcererLevel = 12,     GoldCost = 325, SM = "+0", Duration = "Check", Distance = "Touch", CooldownPeriod = "100", Effect = "see objects concealed by invisibility spell" },
                new Spell { Name = "Shadow", Targeted = true,                   HealerLevel = null, WizardLevel = 6, SorcererLevel = 2,     GoldCost = 75, SM = "+0", TM = "-(MOB+AU)/2", Duration = "Check/2", Distance = "INx5", CooldownPeriod = "5", Effect = "-8 all checks requiring sights. immune: Eyeless undead and naturally blind" },
                new Spell { Name = "Shadow Arrow", Targeted = true,             HealerLevel = null, WizardLevel = 6, SorcererLevel = 2,     GoldCost = 75, SM = "+2", Duration = "Instant", Distance = "INx10", CooldownPeriod = "0", Effect = "BeingOfLight -2 def to this spell, Not usable by ServantOfLight" },
                new Spell { Name = "Shadow Blade", Targeted = true,             HealerLevel = null, WizardLevel = 8, SorcererLevel = 7,     GoldCost = 360, SM = "+0", Duration = "Check", Distance = "INx2", CooldownPeriod = "100", Effect = "For ServantsOfDark: WB+1, -1 Def per attack. No Stack: Scorching, Artic, Burning Faith, Light, Not usable by ServantOfLight" },
                new Spell { Name = "Shadow Lance", Targeted = true,             HealerLevel = null, WizardLevel = 15, SorcererLevel = 10,   GoldCost = 595, SM = "+5", Duration = "Instant", Distance = "INx10", CooldownPeriod = "0", Effect = "BeingOfLight -2 def to this spell, Not usable by ServantOfLight" },
                new Spell { Name = "Shadow Pillar", Targeted = true,            HealerLevel = null, WizardLevel = 20, SorcererLevel = 15,   GoldCost = 920, SM = "+8", Duration = "Instant", Distance = "INx10", CooldownPeriod = "1", Effect = "check+=Retribution, BeignOfLight -2 def to this spell, Not usable by ServantOfLight" },
                new Spell { Name = "Shrink",                                    HealerLevel = null, WizardLevel = 10, SorcererLevel = 8,    GoldCost = 460, SM = "-4", Duration = "Check min", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "voluntary target (size,BOD,ST,CO,MR)/10" },
                new Spell { Name = "Silence", Targeted = true,                  HealerLevel = 12, WizardLevel = 10, SorcererLevel = 8,      GoldCost = 395, SM = "+0", TM = "-(MND+AU)/2", Duration = "IN/2", Distance = "INx2", CooldownPeriod = "100", Effect = "silenced. Mages: penalties when casting" },
                new Spell { Name = "Sleep", MindInfluencing = true,             HealerLevel = 2, WizardLevel = 5, SorcererLevel = 5,        GoldCost = 45, SM = "+0", TM = "-(BOD+IN)/2", Duration = "Instant", Distance = "INx2 radius", CooldownPeriod = "10", Effect = "LVL # sleep. end by noise/disturbance" },
                new Spell { Name = "Slow",                                      HealerLevel = 3, WizardLevel = 8, SorcererLevel = 8,        GoldCost = 80, SM = "+0", TM = "-(BOD+AU)/2", Duration = "IN", Distance = "INx5 radius", CooldownPeriod = "10", Effect = "LVL/2 # targets get MR/2" },
                new Spell { Name = "Sprint",                                    HealerLevel = 7, WizardLevel = 7, SorcererLevel = 7,        GoldCost = 220, SM = "-2", Duration = "Check", Distance = "Touch", CooldownPeriod = "100", Effect = "MRx2" },
                new Spell { Name = "Sternutation", Targeted = true,             HealerLevel = 1, WizardLevel = 3, SorcererLevel = 3,        GoldCost = 10, SM = "+0", TM = "-(BOD+AU)/2", Duration = "1", Distance = "INx2", CooldownPeriod = "0", Effect = "violent sneezing, MR/2, end on damage" },
                new Spell { Name = "Strengthen Defensive Shield",               HealerLevel = 4, WizardLevel = null, SorcererLevel = null,  GoldCost = 230, SM = "+0", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "doubles Def bonus of active Defensive Shield" },
                new Spell { Name = "Stumble", Targeted = true,                  HealerLevel = null, WizardLevel = 4, SorcererLevel = 3,     GoldCost = 140, SM = "+0", TM = "-(MOB+AU)/2", Duration = "Instant", Distance = "INx5", CooldownPeriod = "100", Effect = "crashes to ground, MOB+DX check or drops held items" },
                new Spell { Name = "Summon Demon",                              HealerLevel = null, WizardLevel = 17, SorcererLevel = 10,   GoldCost = 1190, SM = "+0", TM = "-(BOD+AU)", Duration = "INx2 hours", Distance = "IN radius", CooldownPeriod = "24 hours", Effect = "BAM demon until IN/2 orders. Unusable by ServantOfLight" },
                new Spell { Name = "Summon Elemental",                          HealerLevel = null, WizardLevel = 10, SorcererLevel = 16,   GoldCost = 920, SM = "+0", TM = "-ElementalLevel x 5", Duration = "IN", Distance = "IN radius", CooldownPeriod = "24 hours", Effect = "BAM elemental until IN/2 orders" },
                new Spell { Name = "Telekenisis", Targeted = true,              HealerLevel = null, WizardLevel = 6, SorcererLevel = 8,     GoldCost = 260, SM = "+0", TM = "-1 per LVLx5 kg", Duration = "Concentration", Distance = "INx5", CooldownPeriod = "0", Effect = "float inanimate object 1m per round" },
                new Spell { Name = "Teleport",                                  HealerLevel = 20, WizardLevel = 10, SorcererLevel = 10,     GoldCost = 920, SM = "+0", TM = "-1 per ally", Duration = "Instant", Distance = "Touch", CooldownPeriod = "24 hours", Effect = "teleports IN allies to known location. CTN/2 if known vaguely. Fumble: in object D20 (2D20 vague) undefendable" },
                new Spell { Name = "Terrify", MindInfluencing = true,           HealerLevel = 5, WizardLevel = 9, SorcererLevel = 7,        GoldCost = 300, SM = "+0", TM = "-(MND+IN)/2", Duration = "IN min", Distance = "INx5 radius", CooldownPeriod = "24 hours", Effect = "LVL # targets flee. end on damage" },
                new Spell { Name = "Throw Voice",                               HealerLevel = null, WizardLevel = 2, SorcererLevel = 3,     GoldCost = 60, SM = "+0", TM = "-1 per 10m", Duration = "INx2", Distance = "Self", CooldownPeriod = "100", Effect = "up to INx10 m along line of sight" },
                new Spell { Name = "Time Stop",                                 HealerLevel = null, WizardLevel = 15, SorcererLevel = 20,   GoldCost = 2130, SM = "-5", Duration = "check", Distance = "Self", CooldownPeriod = "D20 days", Effect = "freeze time, cannot move objects, end on dealing/receiving damage" },
                new Spell { Name = "Transformation", MindInfluencing = true,    HealerLevel = null, WizardLevel = 5, SorcererLevel = 10,    GoldCost = 420, SM = "-2", Duration = "Check/2 hours", Distance = "Self", CooldownPeriod = "24 hours", Effect = "same race/gender. specific person fails on perception check. immune: undead" },
                new Spell { Name = "Vaporize", Targeted = true,                 HealerLevel = null, WizardLevel = 20, SorcererLevel = 18,   GoldCost = 2230, SM = "+0", TM = "-(BOD+AU)/2", Duration = "Instant", Distance = "IN", CooldownPeriod = "24 hours", Effect = "Damage = check x3, Def = no armor, immune: no water, skeletons, fire elements" },
                new Spell { Name = "Wall of Stone",                             HealerLevel = null, WizardLevel = 10, SorcererLevel = 14,   GoldCost = 920, SM = "-2", Duration = "Instant", Distance = "INx2", CooldownPeriod = "24 hours", Effect = "permanent 1xINxIN stone wall on solid ground. Def = LVLx3, HP = LVL" },
                new Spell { Name = "Water Walking",                             HealerLevel = 5, WizardLevel = 9, SorcererLevel = 9,        GoldCost = 150, SM = "+0", Duration = "IN hours", Distance = "Touch", CooldownPeriod = "0", Effect = "target can active/deactivate" },
                new Spell { Name = "Weapon of Light", Targeted = true,          HealerLevel = 7, WizardLevel = 8, SorcererLevel = null,     GoldCost = 220, SM = "+0", Duration = "Check", Distance = "INx2", CooldownPeriod = "100", Effect = "ServantOfLight: WB+1, User Def+1 on attack. No Stack: Artic, Scorching, Shadow, Not usable by ServantsOfDark" }
                );
            #endregion

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
