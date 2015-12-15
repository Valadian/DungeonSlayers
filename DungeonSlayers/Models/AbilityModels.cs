﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Talent : Identifiable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Restriction> Restrictions { get; set; }
        public ICollection<Modifier> Modifiers { get; set; }
    }
    public class Restriction : Identifiable
    {
        public string className { get; set; }
        public int MaxLevel { get; set; }
        public int RequiredLevel { get; set; }
    }
    public class Spell : Identifiable
    {
        public string Name { get; set; }
        public string CB { get; set; }
        public bool Targeted { get; set; }
        //-1 Self, 0 touch, >0 ranged
        public string Distance { get; set; }
        public int CooldownPeriod { get; set; }
        public string Effect { get; set; }
        public int Level { get; set; }
        public int GoldCost { get; set; }
    }
    public class RacialAbility : Identifiable
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public Modifier Modifier { get; set; }
    }
}