using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Talent : Modified
    {
        public string Description { get; set; }
        public ICollection<Restriction> Restrictions { get; set; }
    }
    public class Restriction : Identifiable
    {
        public string className { get; set; }
        public int Ranks { get; set; }
        public int Level { get; set; }
    }
    public class Spell : NamedIdentifiable
    {
        public string SM { get; set; }
        public string TM { get; set; }
        public bool Targeted { get; set; } = false;
        public bool MindInfluencing { get; set; } = false;
        public string Duration { get; set; }
        //-1 Self, 0 touch, >0 ranged
        public string Distance { get; set; }
        public string CooldownPeriod { get; set; }
        public string Effect { get; set; }
        public int? HealerLevel { get; set; }
        public int? WizardLevel { get; set; }
        public int? SorcererLevel { get; set; }
        public int GoldCost { get; set; }
    }
    public class RacialAbility : Modified
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}