using DungeonSlayers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Repositories
{
    public static class PropertyRepo
    {
        public static IEnumerable<PropertyDef> Attributes(this IEnumerable<PropertyDef> props)
        {
            return props.Where(p => p.PropType == PropertyType.Attribute);
        }
        public static IEnumerable<PropertyDef> Traits(this IEnumerable<PropertyDef> props)
        {
            return props.Where(p => p.PropType == PropertyType.Trait);
        }
        public static IEnumerable<PropertyDef> AttributesAndTraits(this IEnumerable<PropertyDef> props)
        {
            return props.Where(p => p.PropType == PropertyType.Attribute || p.PropType == PropertyType.Trait);
        }
        public static IEnumerable<PropertyDef> CombatValues(this IEnumerable<PropertyDef> props)
        {
            return props.Where(p => p.PropType == PropertyType.CombatValue);
        }
        //public static PropertyName[] AttributesAndTraits = new[]{
        //    PropertyName.Body,
        //    PropertyName.Mobility,
        //    PropertyName.Mind,
        //    PropertyName.Strength,
        //    PropertyName.Constitution,
        //    PropertyName.Agility,
        //    PropertyName.Dexterity,
        //    PropertyName.Intellect,
        //    PropertyName.Aura };
        //public static PropertyName[] CombatValues = new[] {
        //    PropertyName.HitPoints,
        //    PropertyName.Defense,
        //    PropertyName.Initiative,
        //    PropertyName.MovementRate,
        //    PropertyName.MeleeAttack,
        //    PropertyName.RangedAttack,
        //    PropertyName.Spellcasting,
        //    PropertyName.TargetedSpellcasting};
    }
}