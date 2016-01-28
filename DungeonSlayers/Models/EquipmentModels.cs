using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public enum Availability { Hamlets, Villages, Cities, Elven, Dwarven, Temple }
    public abstract class Modified : NamedIdentifiable
    {
        public ICollection<Modifier> Modifiers { get; set; }
    }
    public abstract class Gear : Modified
    {
        public string Effect { get; set; }
        public Availability Availability { get; set; }
        public double Price { get; set; } //In Gold
    }
    public class Equipment : Gear
    {

    }
    public class Armor : Gear
    {
        ICollection<Modifier> BaseModifiers { get; set; }
        public int AV { get; set; }
        public bool BreakDEFFumble { get; set; }
    }
    public class Weapon : Gear
    {
        ICollection<Modifier> BaseModifiers { get; set; }
        public int WeaponBonus { get; set; }
        public int MagicModifier { get; set; }
        public bool Melee { get; set; } = true;
        public bool Ranged { get; set; } = false;
        public bool TwoHanded { get; set; }
        public bool Unwieldy { get; set; }
        public bool BreakMATFumble { get; set; }
        public bool BreakRATFumble { get; set; }
        public bool HitsSelfFumble { get; set; }
    }
}