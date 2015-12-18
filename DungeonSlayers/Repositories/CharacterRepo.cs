using DungeonSlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Repositories
{
    public static class CharacterRepo
    {
        public static Character Initialize(this Character character, ApplicationDbContext db)
        {
            var properties = db.PropertyDefs.AttributesAndTraits().Select((def, i) => new Property { Id = i, Definition = def, Base = 0 }).ToList();
            foreach(var prop in properties)
            {
                var propInfo = character.GetType().GetProperties().Where(p => p.Name == prop.Definition.Name.ToString()).First();
                propInfo.SetValue(character, prop);
            }
            return character;
        }
    }
}