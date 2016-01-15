using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public enum Availability { Hamlets, Villages, Cities, Elven, Dwarven }
    public class Equipment : Identifiable
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public Availability Availability { get; set; }
        public double Price { get; set; } //In Gold
    }
    public class Armor : Equipment
    {
        ICollection<Modifier> BaseModifiers { get; set; }
        public int AV { get; set; }
    }
    public class Weapon : Equipment
    {
        ICollection<Modifier> BaseModifiers { get; set; }
        public int WeaponBonus { get; set; }
        public int MagicModifier { get; set; }
        public bool Ranged { get; set; }
        public bool TwoHanded { get; set; }
        public bool Unwieldy { get; set; }
        public bool BreakMATFumble { get; set; }
        public bool BreakRATFumble { get; set; }
        public bool HitsSelfFumble { get; set; }
    }
}