using DungeonSlayers.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<RacialAbility> RacialAbilities { get; set; }
        public DbSet<Race> DefaultRaces { get; set; }
        public DbSet<BaseClass> Classes { get; set; }
        public DbSet<HeroClass> HeroClasses { get; set; }
        public DbSet<PropertyDef> PropertyDefs { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasMany(e => e.RacialAbilities)
                .WithMany()
                .Map(s =>
                {
                    s.MapLeftKey("CharacterId");
                    s.MapRightKey("RacialId");
                    s.ToTable("CharacterRacialAbilities");
                });

            modelBuilder.Entity<Race>()
                .HasMany(e => e.RacialAbilities)
                .WithMany()
                .Map(s =>
                {
                    s.MapLeftKey("RefRaceId");
                    s.MapRightKey("RacialId");
                    s.ToTable("RefRaceRacialAbilities");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}