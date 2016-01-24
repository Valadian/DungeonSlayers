using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Race : NamedIdentifiable
    {
        public ICollection<RacialAbility> RacialAbilities { get; set; }
    }

    public class BaseClass : NamedIdentifiable
    {

        public ICollection<HeroClass> HeroClasses { get; set; }
    }

    public class HeroClass : NamedIdentifiable
    {
        public BaseClass BaseClass { get; set; }
    }
}