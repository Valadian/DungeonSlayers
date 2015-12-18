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
                new RacialAbility { Name = "Allergic to Metal -2RP",Value = -2},
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
            context.PropertyDefs.AddOrUpdate(p => p.Name,
                new PropertyDef { Name = PropertyName.Body, PropType = PropertyType.Attribute, Acronym = "BOD", DisplayName = "Body"},
                new PropertyDef { Name = PropertyName.Mobility, PropType = PropertyType.Attribute, Acronym = "MOB", DisplayName = "Mobility" },
                new PropertyDef { Name = PropertyName.Mind, PropType = PropertyType.Attribute, Acronym = "MND", DisplayName = "Mind" },

                new PropertyDef { Name = PropertyName.Strength, PropType = PropertyType.Trait, Acronym = "ST", DisplayName = "Strength" },
                new PropertyDef { Name = PropertyName.Constitution, PropType = PropertyType.Trait, Acronym = "CO", DisplayName = "Constitution" },
                new PropertyDef { Name = PropertyName.Dexterity, PropType = PropertyType.Trait, Acronym = "AG", DisplayName = "Dexterity" },
                new PropertyDef { Name = PropertyName.Agility, PropType = PropertyType.Trait, Acronym = "DX", DisplayName = "Agility" },
                new PropertyDef { Name = PropertyName.Intellect, PropType = PropertyType.Trait, Acronym = "IN", DisplayName = "Intellect" },
                new PropertyDef { Name = PropertyName.Aura, PropType = PropertyType.Trait, Acronym = "AU", DisplayName = "Aura" },

                new PropertyDef { Name = PropertyName.HitPoints, PropType = PropertyType.CombatValue, Acronym = "HP", DisplayName = "Hit Points", Derived = true, Equation = "@BOD+@CO+10" },
                new PropertyDef { Name = PropertyName.Defense, PropType = PropertyType.CombatValue, Acronym = "DEF", DisplayName = "Defense", Derived = true, Equation = "@BOD+@CO+@AV" },
                new PropertyDef { Name = PropertyName.Initiative, PropType = PropertyType.CombatValue, Acronym = "INI", DisplayName = "Initiative", Derived = true, Equation = "@MOV+@AG" },
                new PropertyDef { Name = PropertyName.MovementRate, PropType = PropertyType.CombatValue, Acronym = "MR", DisplayName = "Movement", Derived = true, Equation = "@MOB/2+1" },
                new PropertyDef { Name = PropertyName.MeleeAttack, PropType = PropertyType.CombatValue, Acronym = "MAT", DisplayName = "MAT", Derived = true, Equation = "@BOD+@ST+@WB" },
                new PropertyDef { Name = PropertyName.RangedAttack, PropType = PropertyType.CombatValue, Acronym = "RAT", DisplayName = "RAT", Derived = true, Equation = "@MOB+@DX+@WB" },
                new PropertyDef { Name = PropertyName.Spellcasting, PropType = PropertyType.CombatValue, Acronym = "SPC", DisplayName = "SPC", Derived = true, Equation = "@MND+@AU-@AV+@SM" },
                new PropertyDef { Name = PropertyName.TargetedSpellcasting, PropType = PropertyType.CombatValue, Acronym = "TSC", DisplayName = "TSC", Derived = true, Equation = "@MND+@DX-@AV+@SM" },

                new PropertyDef { Name = PropertyName.ArmorValue, PropType = PropertyType.Misc, Acronym = "AV", DisplayName = "SUM AV" },
                new PropertyDef { Name = PropertyName.WeaponBonus, PropType = PropertyType.Misc, Acronym = "WB", DisplayName = "WB" },
                new PropertyDef { Name = PropertyName.SpellModifier, PropType = PropertyType.Misc, Acronym = "SM", DisplayName = "SM" }
            );


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
