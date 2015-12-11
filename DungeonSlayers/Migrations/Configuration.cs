namespace DungeonSlayers.Migrations
{
    using Models;
    using System;
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
            context.RacialAbilities.AddOrUpdate(p => p.Name,
                new RacialAbility { Name = "Allergic to Metal -2RP"},
                new RacialAbility { Name = "Arrogant -1RP" },
                new RacialAbility { Name = "Darkvision +1RP" },
                new RacialAbility { Name = "Monocular -1RP" },
                new RacialAbility { Name = "Fragile -1RP" },
                new RacialAbility { Name = "Quick +1RP" },
                new RacialAbility { Name = "Gold Lust -1RP" },
                new RacialAbility { Name = "Large +4RP" },
                new RacialAbility { Name = "Small -4RP" },
                new RacialAbility { Name = "Longevity +0RP" },
                new RacialAbility { Name = "Fleet Footed +1RP" },
                new RacialAbility { Name = "Light Sensitivity -1RP" },
                new RacialAbility { Name = "Magic Resistance -1RP" },
                new RacialAbility { Name = "Magically Gifted +1RP" },
                new RacialAbility { Name = "Magically Impotent -1RP" },
                new RacialAbility { Name = "Night Vision +1RP" },
                new RacialAbility { Name = "Fast +1RP" },
                new RacialAbility { Name = "Gifted +2RP" },
                new RacialAbility { Name = "Clumsy -2RP" },
                new RacialAbility { Name = "Unkempt -1RP" },
                new RacialAbility { Name = "Immortal +0RP" },
                new RacialAbility { Name = "Incompetent -4RP" },
                new RacialAbility { Name = "Despised -1RP" },
                new RacialAbility { Name = "Tough +1RP" },
                new RacialAbility { Name = "More than meets the eye +3RP" },
                new RacialAbility { Name = "Sure Shot +1RP" },
                new RacialAbility { Name = "Slow -1RP" }
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
