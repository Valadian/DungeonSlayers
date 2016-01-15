using DungeonSlayers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DungeonSlayers.Repositories
{
    public static class ChoicesRepo
    {
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<ApplicationUser> users)
        {
            return users.Select(u => new SelectListItem() { Value = u.Id, Text = u.UserName });
            //ViewBag.OwnerChoices = new[] { "berge403", "unitive", "jacky" }.Select(s => new SelectListItem() { Value = s, Text = s }); //["OwnerChoices"] = 

        }
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<RacialAbility> users)
        {
            return users.Select(ra => new SelectListItem() { Value = ra.Id.ToString(), Text = ra.Name });

        }
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<Race> races, bool valueStrings = false)
        {
            return races.Select(s => new SelectListItem() { Value = valueStrings?s.Name:s.Id.ToString(), Text = s.Name });

            //ViewBag.RaceChoices = new[] { "Human", "Elf", "Dwarf", "Orc" }.Select(s => new SelectListItem() { Value = s, Text = s }); //["RaceChoices"] = 
        }
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<BaseClass> classes, bool valueStrings = false)
        {
            return classes.Select(s => new SelectListItem() { Value = valueStrings ? s.Name : s.Id.ToString(), Text = s.Name });

            //ViewBag.ClassChoices = new[] { "Fighter", "Scout", "Healer", "Wizard", "Sorcerer" }.Select(s => new SelectListItem() { Value = s, Text = s});
        }
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<Weapon> classes, bool valueStrings = false)
        {
            return classes.Select(s => new SelectListItem() { Value = valueStrings ? s.Name : s.Id.ToString(), Text = s.Name });
        }
        public static IEnumerable<SelectListItem> AsChoices(this IDbSet<HeroClass> classes, bool valueStrings = false)
        {
            return classes.Select(s => new SelectListItem() { Value = valueStrings ? s.Name : s.Id.ToString(), Text = s.Name, Group = new SelectListGroup() { Name = s.BaseClass.Name } }).ToList()
                .Union(new[] { new SelectListItem() { Value = null, Text = "No Hero Class", Group=null} });


            //var groups = new Dictionary<string, SelectListGroup>()
            //{
            //    {"Fighter", new SelectListGroup() { Name = "Fighter" }},
            //    {"Scout", new SelectListGroup() { Name = "Scout" }},
            //    {"Healer", new SelectListGroup() { Name = "Healer" }},
            //    {"Wizard", new SelectListGroup() { Name = "Wizard" }},
            //    {"Sorcerer", new SelectListGroup() { Name = "Sorcerer" }},
            //};

            //var heroclasses = new List<SelectListItem>();
            //heroclasses.Add(new SelectListItem() { Text = "Nothing selected", Value = "" });
            //heroclasses.AddRange(new[] { "Berserker", "Paladin", "Weapon Master" }.Select(hc => new SelectListItem() { Value = hc, Text = hc, Group = groups["Fighter"] }));
            //heroclasses.AddRange(new[] { "Assassin", "Ranger", "Rogue" }.Select(hc => new SelectListItem() { Value = hc, Text = hc, Group = groups["Scout"] }));
            //heroclasses.AddRange(new[] { "Cleric", "Druid", "Monk" }.Select(hc => new SelectListItem() { Value = hc, Text = hc, Group = groups["Healer"] }));
            //heroclasses.AddRange(new[] { "Archmage", "Battle Mage", "Elementalist" }.Select(hc => new SelectListItem() { Value = hc, Text = hc, Group = groups["Wizard"] }));
            //heroclasses.AddRange(new[] { "Blood Mage", "Demonologist", "Necromancer" }.Select(hc => new SelectListItem() { Value = hc, Text = hc, Group = groups["Sorcerer"] }));
        }
    }
}