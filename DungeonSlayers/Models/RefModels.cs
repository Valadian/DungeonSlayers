using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Race : Identifiable
    {
        public string Name { get; set; }
        public ICollection<RacialAbility> RacialAbilities { get; set; }
    }

    public class BaseClass : Identifiable
    {
        public string Name { get; set; }

        public ICollection<HeroClass> HeroClasses { get; set; }
    }

    public class HeroClass : Identifiable
    {
        public string Name { get; set; }
        public BaseClass BaseClass { get; set; }
    }
}