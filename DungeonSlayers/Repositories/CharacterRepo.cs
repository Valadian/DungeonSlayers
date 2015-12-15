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
            character.Properties = db.PropertyDefs.AttributesAndTraits().Select((def,i) => new Property { Id = i, Definition = def }).ToList();
            return character;
        }
    }
}