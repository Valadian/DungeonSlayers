using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Equipment : Identifiable
    {
        public string Name { get; set; }
        public string Effect { get; set; }
    }
    public class Armor : Identifiable
    {
        public string Name { get; set; }
        ICollection<Modifier> BaseModifiers { get; set; }
        public int AV { get; set; }
        public string Effect { get; set; }
    }
    public class Weapon : Identifiable
    {
        public string Name { get; set; }
        ICollection<Modifier> BaseModifiers { get; set; }
        public int WeaponBonus { get; set; }
        public int MagicModifier { get; set; }
        public bool Ranged { get; set; }
        public string Effect { get; set; }
    }
}